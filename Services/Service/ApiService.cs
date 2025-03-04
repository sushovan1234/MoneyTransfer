using MoneyTransfer.Models;
using MoneyTransfer.Services.Interface;
using Newtonsoft.Json;

namespace MoneyTransfer.Services.Service
{
    public class ApiService : IApiService
    {
        private readonly IConfiguration configuration;
        public ApiService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<ApiResponse> GetDatas(string fromdate, string todate)
        {
            string baseurl = configuration["ApiEndpoint:exchangerateUrl"];
            string url = $"{baseurl}?page=1&per_page=5&from={fromdate}&to={todate}";
            HttpClient httpClient = new HttpClient();
            string responseMessage = await httpClient.GetStringAsync(url);
            ApiResponse json = JsonConvert.DeserializeObject<ApiResponse>(responseMessage);
            return json;

        }
    }
}
