using System;
using System.Security.Claims;

namespace LyteChat.Server.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetUserEmail(this ClaimsPrincipal claimsPrincipal)
    {
        Claim? emailClaim = claimsPrincipal.FindFirst(ClaimTypes.Email);
        ArgumentException.ThrowIfNullOrEmpty(emailClaim?.Value, "Email");
        return emailClaim.Value;
    }
}