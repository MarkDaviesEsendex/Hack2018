using Abp.MultiTenancy;
using Esendexers.HomelessWays.Authorization.Users;

namespace Esendexers.HomelessWays.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
