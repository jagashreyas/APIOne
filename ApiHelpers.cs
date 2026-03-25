using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightAPIAutomation.Utils
{
    public class ApiHelper
    {
        private readonly IAPIRequestContext _request;

        public ApiHelper(IPlaywright playwright)
        {
            _request = playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "https://reqres.in/api"
            }).Result;
        }

        public async Task<IAPIResponse> GetAsync(string endpoint)
        {
            return await _request.GetAsync(endpoint);
        }

        public async Task<IAPIResponse> PostAsync(string endpoint, object data)
        {
            return await _request.PostAsync(endpoint, new APIRequestContextOptions
            {
                DataObject = data
            });
        }
    }
}
