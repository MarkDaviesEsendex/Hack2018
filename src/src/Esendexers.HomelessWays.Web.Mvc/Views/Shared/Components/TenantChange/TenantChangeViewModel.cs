using Abp.AutoMapper;
using Esendexers.HomelessWays.Sessions.Dto;

namespace Esendexers.HomelessWays.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
