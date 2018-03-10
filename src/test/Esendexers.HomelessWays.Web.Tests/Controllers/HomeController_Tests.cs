using System.Threading.Tasks;
using Esendexers.HomelessWays.Web.Controllers;
using Shouldly;
using Xunit;

namespace Esendexers.HomelessWays.Web.Tests.Controllers
{
    public class HomeController_Tests: HomelessWaysWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
