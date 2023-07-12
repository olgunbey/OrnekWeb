using IdentityServer4.Models;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Security.Claims;

namespace IdentityServer4.AuthServer
{
    public static class Config
    {
        public static IEnumerable<Client> Clients => new List<Client>()
        {
            new Client()
            {
                ClientId="Client1",
                ClientSecrets=new[]{new Secret("secret".Sha256())},
                AllowedScopes={"api1.client"}, //client1'den üretilecek tokenin erişebileceği scopelar
                AllowedGrantTypes=GrantTypes.ClientCredentials
                
            },
            new Client()
            {
                ClientId="Client1-ResourceOwner",
                ClientSecrets=new[]{new Secret("secrets".Sha256())},
                AllowedScopes={"api1.update", "Roles",IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile},
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                AbsoluteRefreshTokenLifetime=DateTime.UtcNow.AddDays(30).Second,
                AccessTokenLifetime=DateTime.UtcNow.AddMinutes(5).Second,
                RefreshTokenUsage=TokenUsage.ReUse,
                RefreshTokenExpiration=TokenExpiration.Absolute,
                AllowOfflineAccess=true,
                
            }

        };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>()
        { 
            new ApiScope("api1.read"),
            new ApiScope("api1.update"),
            new ApiScope("api1.write"),
            new ApiScope("api1.deleted"),
            new ApiScope("api1.client")
        
        };
        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>()
        {
            new ApiResource("apiResource")
            {
                Scopes={"api1.read","api1.update","api1.write","api1.deleted","api1.client"},
                ApiSecrets={new Secret("api1Secret".Sha256()) }
            }
            
        };

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>() 
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource()
            {
                Name="Roles",
                UserClaims=new[]{ClaimTypes.Role}
            }
            
        
        };
    }
}