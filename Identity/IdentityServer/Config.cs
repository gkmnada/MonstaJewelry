using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog")
            {
                Scopes = { "CatalogFullPermission", "CatalogReadPermission" }
            },
            new ApiResource("ResourceDiscount")
            {
                Scopes = { "DiscountFullPermission", "DiscountReadPermission" }
            },
            new ApiResource("ResourceOrder")
            {
                Scopes = { "OrderFullPermission", "OrderReadPermission" }
            },
            new ApiResource("ResourceCargo")
            {
                Scopes = { "CargoFullPermission", "CargoReadPermission" }
            },
            new ApiResource("ResourceBasket")
            {
                Scopes = { "BasketFullPermission", "BasketReadPermission" }
            },
            new ApiResource("ResourceOcelot")
            {
                Scopes = { "OcelotFullPermission" }
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full access to catalog API"),
            new ApiScope("CatalogReadPermission", "Read access to catalog API"),
            new ApiScope("DiscountFullPermission", "Full access to discount API"),
            new ApiScope("DiscountReadPermission", "Read access to discount API"),
            new ApiScope("OrderFullPermission", "Full access to order API"),
            new ApiScope("OrderReadPermission", "Read access to order API"),
            new ApiScope("CargoFullPermission", "Full access to cargo API"),
            new ApiScope("CargoReadPermission", "Read access to cargo API"),
            new ApiScope("BasketFullPermission", "Full access to basket API"),
            new ApiScope("BasketReadPermission", "Read access to basket API"),
            new ApiScope("OcelotFullPermission", "Full access to ocelot API"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId = "VisitorClient",
                ClientName = "Visitor Client",
                ClientSecrets = { new Secret("visitorsecret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "CatalogReadPermission", "DiscountReadPermission", "OrderReadPermission", "CargoReadPermission", "BasketReadPermission" }
            },
            new Client
            {
                ClientId = "AdminClient",
                ClientName = "Administrator Client",
                ClientSecrets = { new Secret("adminsecret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes = { "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission", "CargoFullPermission", "BasketFullPermission", "OcelotFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 1 * 60 * 60
            }
        };
    }
}