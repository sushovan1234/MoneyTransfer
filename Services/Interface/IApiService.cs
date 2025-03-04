using MoneyTransfer.Models;

namespace MoneyTransfer.Services.Interface
{
    public interface IApiService
    {
        Task<ApiResponse> GetDatas(string fromdate, string todate);
    }
}
