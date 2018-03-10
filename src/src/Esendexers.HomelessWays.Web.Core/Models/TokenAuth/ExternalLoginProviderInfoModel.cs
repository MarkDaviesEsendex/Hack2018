using Abp.AutoMapper;
using Esendexers.HomelessWays.Authentication.External;

namespace Esendexers.HomelessWays.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
