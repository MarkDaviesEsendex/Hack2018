using System.Collections.Generic;

namespace Esendexers.HomelessWays.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
