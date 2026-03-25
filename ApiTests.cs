using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
using PlaywrightAPIAutomation.Utils;
using PlaywrightAPIAutomation.Models;

namespace PlaywrightAPIAutomation.Tests
{
    public class ApiTests
    {
        private IPlaywright _playwright;
        private ApiHelper _apiHelper;

        [OneTimeSetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            _apiHelper = new ApiHelper(_playwright);
        }

        [Test]
        public async Task GetUsers_ShouldReturn200()
        {
            var response = await _apiHelper.GetAsync("/users?page=2");

            Assert.AreEqual(200, response.Status);
        }

        [Test]
        public async Task CreateUser_ShouldReturn201()
        {
            var user = new UserModel
            {
                name = "Jagadamba",
                job = "QA Engineer"
            };

            var response = await _apiHelper.PostAsync("/users", user);

            Assert.AreEqual(201, response.Status);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _playwright?.Dispose();
        }
    }
}
