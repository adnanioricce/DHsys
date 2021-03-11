using System.Collections.Generic;
using IdentityServer4.Models;

namespace Api
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityServer4.Models.IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource("roles","User Role(s)",new [] {"admin","dev","operator"})
            };
        public static IEnumerable<IdentityServer4.Models.ApiScope> ApiScopes =>
            new List<IdentityServer4.Models.ApiScope>{
                new IdentityServer4.Models.ApiScope("dhsysapi","DHsys API"),
                new ApiScope("swagger","DHsys API Docs"),
                new ApiScope("admin", "api scope of admins"),
                new ApiScope("operator", "api scope of operators")                
            };
        public static IEnumerable<IdentityServer4.Models.Client> Clients => new List<IdentityServer4.Models.Client>{
            new IdentityServer4.Models.Client{
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                // secret for authentication
                ClientSecrets =
                {
                    new IdentityServer4.Models.Secret("secret".Sha256())
                },                
                // scopes that client has access to
                AllowedScopes = { "dhsysapi" }
            },
            new Client {
                ClientId = "swagger",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                ClientSecrets = {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "swagger" }
            }
        };
    }
}