using System.Threading.Tasks;
using Safenet.Models.TokenAuth;
using Safenet.Web.Controllers;
using Shouldly;
using Xunit;

namespace Safenet.Web.Tests.Controllers
{
    public class HomeController_Tests: SafenetWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}