using System.Collections.Generic;
using IdentityServer4.Models;
static public class Config {
    #region Scope
    //API'larda kullanılacak izinleri tanımlar.
    public static IEnumerable<ApiScope> GetApiScopes(){
        return new List<ApiScope>{
            new ApiScope("Garanti.Write", "Garanti Bankasi yazma izni"),
            new ApiScope("Garanti.Read", "Garanti bankasi okuma izni"),
            new ApiScope("HalkBank.Write","HalkBank bankasi yazma izni"),
            new ApiScope("HalkBank.Read","HalkBank bankasi okuma izni")
        };
    }
    #endregion
    
    #region 
    //API'lar tanımlanır
    public static IEnumerable<ApiResource> GetApiResources(){
        return new List<ApiResource>{
            new ApiResource("Garanti"){Scopes = {"Garanti.Write","Garanti.Read"}},
            new ApiResource("HalkBank.Write","HalkBank.Read")
        };
    }
    #endregion

    #region 
    //API'ları kullanacak client'lar tanımlanır
    public static IEnumerable<Client> GetClients(){
        return new List<Client>{
            new Client {
                ClientId = "GarantiBankasi",
                ClientName = "GarantiBankasi",
                ClientSecrets = { new Secret("garanti".Sha256())},
                AllowedGrantTypes = {GrantType.ClientCredentials },
                AllowedScopes = {"Garanti.Write", "Garanti.Read"}
            },
            new Client {
                ClientId = "HalkBankasi",
                ClientName = "HalkBankasi",
                ClientSecrets = { new Secret("halkbank".Sha256())},
                AllowedGrantTypes = { GrantType.ClientCredentials },
                AllowedScopes = { "HalkBank.Write", "HalkBank.Read" }
            }
        };
    }
    #endregion
}