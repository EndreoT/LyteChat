using LyteChat.Server.Data.Models;
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
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> Login()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Unauthorized();
            }
            StringValues reqAuthHeader = Request.Headers["Authorization"];
            AuthenticationHeaderValue authHeader = AuthenticationHeaderValue.Parse(reqAuthHeader);
            byte[] credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            string[] credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
            string email = credentials[0];
            string password = credentials[1];
            User user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                JwtSecurityToken token = await GetToken(user);
                return Ok(new LoginResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("login/anonymous")]
        public async Task<ActionResult<LoginResponse>> LoginAsAnonymous()
        {
            var user = await _userManager.FindByEmailAsync(Data.Models.User.AnonymousUserEmail);

            JwtSecurityToken token = await GetToken(user);
            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new LoginResponse
            {
                Token = tokenStr,
                Expiration = token.ValidTo
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("register")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterModel model)
        {
            User userExists = await _userManager.FindByEmailAsync(model.Email);
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

            JwtSecurityToken token = await GetToken(user);
            return Ok(new RegisterResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            });
        }

        private async Task<JwtSecurityToken> GetToken(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
