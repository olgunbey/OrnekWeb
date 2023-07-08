using IdentityServer4.Models;

namespace IdentityServer4.AuthServer
{
    public static class Config
    {
        //public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>()
        //{
        //    new IdentityResource()
        //};
        public static IEnumerable<Client> Clients => new List<Client>()
        {
            new Client()
            {
                ClientId="Client1",
                ClientSecrets=new[]{new Secret("secret".Sha256())},
                AllowedScopes={"api1.read"}, //client1'den üretilecek tokenin erişebileceği scopelar
                AllowedGrantTypes=GrantTypes.ClientCredentials
                
            },
            new Client()
            {
                ClientId="Client12",
                ClientSecrets=new[]{new Secret("secrets".Sha256())},
                AllowedScopes={"api1.update"},
                AllowedGrantTypes=GrantTypes.ClientCredentials
            }
            
        };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>()
        { 
            new ApiScope("api1.read"),
            new ApiScope("api1.update"),
            new ApiScope("api1.write"),
            new ApiScope("api1.deleted")
        
        };
        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>()
        {
            new ApiResource("apiResource")
            {
                Scopes={"api1.read","api1.update","api1.write","api1.deleted"},
                ApiSecrets={new Secret("api1Secret".Sha256()) }
            }
            
        };
    }
}