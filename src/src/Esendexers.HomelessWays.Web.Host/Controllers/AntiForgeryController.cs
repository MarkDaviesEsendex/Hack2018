using Microsoft.AspNetCore.Antiforgery;
using Esendexers.HomelessWays.Controllers;

namespace Esendexers.HomelessWays.Web.Host.Controllers
{
    public class AntiForgeryController : HomelessWaysControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
