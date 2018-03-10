using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Esendexers.HomelessWays.MultiTenancy;

namespace Esendexers.HomelessWays.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
