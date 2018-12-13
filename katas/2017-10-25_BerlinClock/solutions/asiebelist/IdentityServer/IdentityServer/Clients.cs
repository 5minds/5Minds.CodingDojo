using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Models;

namespace IdentityServer
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
                    
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("0Z46VDWJZlwPhQQYyd4PCOdoZXoy9ko6".Sha256())
                        //new Secret("0Z46VDWJZlwPhQQYyd4PCOdoZXoy9ko6".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        "BerlinClockApi"
                    }
                }
            };
        }
    }
}
