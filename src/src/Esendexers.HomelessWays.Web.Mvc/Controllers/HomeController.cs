using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Esendexers.HomelessWays.Controllers;

namespace Esendexers.HomelessWays.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : HomelessWaysControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
