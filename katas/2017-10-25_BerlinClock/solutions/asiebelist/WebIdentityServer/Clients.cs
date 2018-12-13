using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIdentityServer
{
    static class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName="Berlin-Clock View",
                    ClientId="berlinclock",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,
                    AllowedGrantTypes=
                    {
                        GrantType.Hybrid,
                        GrantType.ClientCredentials,
                    },
                    RedirectUris = new List<string>
                    {
                        "http://localhost:50002/api/BerlinClock"
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("0Z46VDWJZlwPhQQYyd4PCOdoZXoy9ko6".Sha256())
                    }
                    ,AllowedScopes = new List<string>
                    {
                        "clockapi.read_only"
                    }
                }
            };
        }
    }
}
