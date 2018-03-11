using Microsoft.AspNetCore.Mvc;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class InvadersController : HomelessWaysControllerBase
    {
        public IActionResult Index() 
            => View();
    }
}