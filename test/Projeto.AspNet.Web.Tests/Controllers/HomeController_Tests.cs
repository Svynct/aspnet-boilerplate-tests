using System.Threading.Tasks;
using Projeto.AspNet.Models.TokenAuth;
using Projeto.AspNet.Web.Controllers;
using Shouldly;
using Xunit;

namespace Projeto.AspNet.Web.Tests.Controllers
{
    public class HomeController_Tests: AspNetWebTestBase
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