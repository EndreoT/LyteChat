using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LyteChat.Server.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IChatGroupUserService _chatGroupUserService;
        private readonly IChatGroupService _chatGroupService;

        private readonly SigningCredentials _signingCredentials;

        public AuthenticateController(
            UserManager<User> userManager,
            IConfiguration configuration,
            IChatGroupUserService chatGroupUserService,
            IChatGroupService chatGroupService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _chatGroupUserService = chatGroupUserService;
            _chatGroupService = chatGroupService;

            string? configSigningKey = _configuration["JWT:Secret"];
            if (string.IsNullOrEmpty(configSigningKey))
            {
                throw new ArgumentException("JWT signing key is not configured");
            }

            SymmetricSecurityKey authSigningKey = new(Encoding.UTF8.GetBytes(configSigningKey));

            _signingCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256);
        }

        /// <summary>
        /// Login as an authenticated user
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> Login()
        {
            if (!Request.Headers.TryGetValue("Authorization", out StringValues reqAuthHeader))
            {
                return Unauthorized();
            }

            string? x= reqAuthHeader[0];
            if (string.IsNullOrEmpty(x))
            {
                return Unauthorized();
            }

            AuthenticationHeaderValue authHeader = AuthenticationHeaderValue.Parse(x);
            if (authHeader.Parameter is null)
            {
                return Unauthorized();
            }
            byte[] credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            string[] credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
            string email = credentials[0];
            string password = credentials[1];
            User? user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                JwtSecurityToken token = await GenerateTokenAsync(user);
                return Ok(new LoginResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        /// <summary>
        /// Login as an anonymous user
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("login/anonymous")]
        public async Task<ActionResult<LoginResponse>> LoginAsAnonymous()
        {
            User? user = await _userManager.FindByEmailAsync(Data.Models.User.AnonymousUserEmail);
            if (user is null)
            {
                return Problem(title: "Internal Server Error", statusCode: 500);
            }

            JwtSecurityToken token = await GenerateTokenAsync(user);
            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new LoginResponse
            {
                Token = tokenStr,
                Expiration = token.ValidTo
            });
        }

        /// <summary>
        /// Register as a new authenticated user
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("register")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterModel model)
        {
            User? userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                return BadRequest(new RegisterResponse { FailureMessage = "User already exists!" });
            }

            User user = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };

            IdentityResult createUserRes = await _userManager.CreateAsync(user, model.Password);
            if (!createUserRes.Succeeded)
            {
                return BadRequest(new RegisterResponse { ErrorList = createUserRes.Errors.ToList() });
            }

            IdentityResult addRoleRes = await _userManager.AddToRoleAsync(user, Role.AuthenticatedUser);
            if (!addRoleRes.Succeeded)
            {
                return BadRequest(new RegisterResponse { ErrorList = createUserRes.Errors.ToList() });
            }

            ChatGroupDTO allChat = await _chatGroupService.GetAllChatAsync();
            //Add user to all chat
            await _chatGroupUserService.AddUserToChatGroupAsync(user, allChat.Uuid);

            JwtSecurityToken token = await GenerateTokenAsync(user);
            return Ok(new RegisterResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            });
        }

        private async Task<JwtSecurityToken> GenerateTokenAsync(User user)
        {
            IList<string> userRoles = await _userManager.GetRolesAsync(user);

            if (user.Email is null || user.UserName is null)
            {
                throw new ArgumentException("User email or username is null");
            }

            List<Claim> authClaims =
            [
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            ];

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            JwtSecurityToken token = new(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: _signingCredentials);

            return token;
        }
    }
}