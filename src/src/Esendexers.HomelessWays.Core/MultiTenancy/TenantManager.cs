using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Esendexers.HomelessWays.Authorization.Users;
using Esendexers.HomelessWays.Editions;

namespace Esendexers.HomelessWays.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
