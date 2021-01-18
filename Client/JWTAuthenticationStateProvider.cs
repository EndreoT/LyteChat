using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Linq;
using LyteChat.Shared.DataTransferObject;

namespace LyteChat.Client
{
    public class JWTAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient Http;
        private readonly IJSRuntime _jsRuntime;
        public JWTAuthenticationStateProvider(HttpClient http, IJSRuntime jsRuntime)
        {
            Http = http;
            _jsRuntime = jsRuntime;
        }

        public async Task SetTokenAsync(string token, DateTime expiry = default)
        {
            if (token == null)
            {
                await _jsRuntime.InvokeAsync<object>("localStorage.removeItem", "authToken");
                await _jsRuntime.InvokeAsync<object>("localStorage.removeItem", "authTokenExpiry");
            }
            else
            {
                await _jsRuntime.InvokeAsync<object>("localStorage.setItem", "authToken", token);
                await _jsRuntime.InvokeAsync<object>("localStorage.setItem", "authTokenExpiry", expiry);
            }

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task<string> GetTokenAsync()
        {
            var expiry = await _jsRuntime.InvokeAsync<object>("localStorage.getItem", "authTokenExpiry");
            if (expiry != null)
            {
                if (DateTime.Parse(expiry.ToString()) > DateTime.Now)
                {
                    return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
                }
                else
                {
                    await SetTokenAsync(null);
                }
            }
            return null;
        }

        public async Task<LoginResponse> RequestTokenForAnonymousUser()
        {
            HttpResponseMessage loginResMessage = await Http.PostAsync("/api/authenticate/login/anonymous", null);
            LoginResponse loginRes = await loginResMessage.Content.ReadFromJsonAsync<LoginResponse>();
            return loginRes;
        }

        public async Task<LoginResponse> RequestTokenForAuthenticatedUser(string username, string password)
        {
            //Only set Basic auth headers for login request
            string loginPath = "api/authenticate/login";
            Uri baseUrl = Http.BaseAddress;
            string urlStr = baseUrl.ToString() + loginPath;
            HttpClient client = new HttpClient();
            byte[] byteArray = Encoding.UTF8.GetBytes($"{username}:{password}");
            AuthenticationHeaderValue header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.DefaultRequestHeaders.Authorization = header;
            //Attempt to login
            HttpResponseMessage response = await client.PostAsync(urlStr, null);
            LoginResponse loginRes = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return loginRes;
        }

        public async Task<RegisterResponse> RegisterUser(RegisterModel registerModel)
        {
            HttpResponseMessage response = await Http.PostAsJsonAsync($"/api/authenticate/register", registerModel);
            RegisterResponse loginRes = await response.Content.ReadFromJsonAsync<RegisterResponse>();
            return loginRes;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await GetTokenAsync();
            ClaimsIdentity identity = string.IsNullOrEmpty(token)
                ? new ClaimsIdentity()
                : new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
            ClaimsPrincipal claimsPrinicpal = new ClaimsPrincipal(identity);

            AuthenticationState authState = new AuthenticationState(claimsPrinicpal);
            return authState;
        }
        private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            string payload = jwt.Split('.')[1];
            byte[] jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }
        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
