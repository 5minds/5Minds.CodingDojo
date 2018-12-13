using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIdentityServer
{
    static class Resources
    {
        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
        public static List<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource{
                    Name="BerlinClockApi",
                    DisplayName="Berlin-Clock API",
                    ApiSecrets =
                    {
                        new Secret("zI3eAaW4U8cN6sEp75QHhgtr5KCDxB1Y".Sha256())
                    },
                    Scopes =
                    {
                        new Scope ()
                        {
                            Name="clockapi.read_only",
                            DisplayName="Lesezugriff auf die Berlin-Clock-API"

                        }
                    }

                }
            };
        }
    }
}
