﻿

using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using GreenTunnel.Core;
using IdentityModel;

namespace GreenTunnel.Infrastructure.IdentityServer.Configurations;

public class IdentityServerConfig
{
    public const string ApiName = "greentunnel_api";
    public const string ApiFriendlyName = "GreenTunnelApp API";
    public const string QuickAppClientID = "greentunnel_spa";
    public const string SwaggerClientID = "swaggerui";

    // Identity resources (used by UserInfo endpoint).
    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Phone(),
            new IdentityResources.Email(),
            new IdentityResource(ScopeConstants.Roles, new List<string> { JwtClaimTypes.Role })
        };
    }

    // Api scopes.
    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new List<ApiScope>
        {
            new ApiScope(ApiName, ApiFriendlyName) {
                UserClaims = {
                    JwtClaimTypes.Name,
                    JwtClaimTypes.Email,
                    JwtClaimTypes.PhoneNumber,
                    JwtClaimTypes.Role,
                    ClaimConstants.Permission
                }
            }
        };
    }

    // Api resources (Needed for audience to be set on token).
    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            new ApiResource(ApiName) {
                Scopes = { ApiName }
            }
        };
    }

    // Clients want to access resources.
    public static IEnumerable<Client> GetClients()
    {
        // Clients credentials.
        return new List<Client>
        {
            // https://docs.duendesoftware.com/identityserver/v6/reference/models/client/
            new Client
            {
                ClientId = QuickAppClientID,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword, // Resource Owner Password Credential grant.
                AllowAccessTokensViaBrowser = true,
                RequireClientSecret = false, // This client does not need a secret to request tokens from the token endpoint.
                    
                AllowedScopes = {
                    IdentityServerConstants.StandardScopes.OpenId, // For UserInfo endpoint.
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Phone,
                    IdentityServerConstants.StandardScopes.Email,
                    ScopeConstants.Roles,
                    ApiName
                },
                AllowOfflineAccess = true, // For refresh token.
                RefreshTokenExpiration = TokenExpiration.Sliding,
                RefreshTokenUsage = TokenUsage.OneTimeOnly,
                //AccessTokenLifetime = 900, // Lifetime of access token in seconds.
                //AbsoluteRefreshTokenLifetime = 7200,
                //SlidingRefreshTokenLifetime = 900,
            },

            new Client
            {
                ClientId = SwaggerClientID,
                ClientName = "Swagger UI",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowAccessTokensViaBrowser = true,
                RequireClientSecret = false,

                AllowedScopes = {
                    ApiName
                }
            }
        };
    }
}