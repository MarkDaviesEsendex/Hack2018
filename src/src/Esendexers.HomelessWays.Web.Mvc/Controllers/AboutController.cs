using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Esendexers.HomelessWays.Controllers;

namespace Esendexers.HomelessWays.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : HomelessWaysControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
