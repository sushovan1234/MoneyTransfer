using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.Models;
using MoneyTransfer.Services.Interface;

namespace MoneyTransfer.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IApiService apiService;

        public DashboardController(IApiService apiService)
        {
            this.apiService = apiService;   
        }
        public async Task<IActionResult> Index()
        {
            ApiResponse Datas = await apiService.GetDatas(DateTime.Now.ToString("yyyy-MM-dd").ToString(), DateTime.Now.ToString("yyyy-MM-dd").ToString());
            return View(Datas);
        }
    }
}
