using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyTransfer.Models;
using MoneyTransfer.Services.Interface;
using MoneyTransfer.ViewModels;
using System.Xml;

namespace MoneyTransfer.Controllers
{
    [Authorize]
    public class TransferController : Controller
    {
        private readonly IBankDetails bankDetails;
        private readonly IBankAccount bankAccount;
        private readonly ITransactionDetails transactionDetails;
        private readonly UserManager<User> userManager;
        private readonly IApiService apiService;

        public TransferController(IBankDetails bankDetails,IBankAccount bankAccount, ITransactionDetails transactionDetails,UserManager<User> userManager,IApiService apiService)
        {
            this.bankDetails = bankDetails;
            this.bankAccount = bankAccount;
            this.transactionDetails = transactionDetails;
            this.userManager = userManager;
            this.apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            var fromBankList = await bankDetails.GetAll(it => it.IsoCode == "MYR");
            var toBankList = await bankDetails.GetAll(it => it.IsoCode == "NPR");
            TransferVM transferVM = new TransferVM();
            transferVM.fromCurrency = "MYR";
            transferVM.toCurrency = "NPR";
            foreach (var bank in fromBankList) 
            {
                transferVM.senderBankList.Add(new SelectListItem { Value = bank.BankId.ToString(), Text = $"{bank.BankName}" });
            
            }

            foreach (var bank in toBankList)
            {
                transferVM.receiverBankList.Add(new SelectListItem { Value = bank.BankId.ToString(), Text = $"{bank.BankName}" });

            }
            var datas = await apiService.GetDatas(DateTime.Now.ToString("yyyy-MM-dd").ToString(), DateTime.Now.ToString("yyyy-MM-dd").ToString());
            var exchangeRate = datas.Data.Payload.SelectMany(it => it.Rates) .FirstOrDefault(rate => rate.Currency.Iso3 == "MYR");
            ViewBag.ExchangeRate = exchangeRate != null ? $" {exchangeRate.Currency.Unit} NPR =  {exchangeRate.Buy} {exchangeRate.Currency.Iso3}" : string.Empty; 
            return View(transferVM);
        }
        [HttpPost]
        public async Task<IActionResult> Index(TransferVM transferVM,string ExchangeRate)
        {
            var fromBankList = await bankDetails.GetAll(it => it.IsoCode == "MYR");
            var toBankList = await bankDetails.GetAll(it => it.IsoCode == "NPR");
            foreach (var bank in fromBankList)
            {
                transferVM.senderBankList.Add(new SelectListItem { Value = bank.BankId.ToString(), Text = $"{bank.BankName}" });

            }

            foreach (var bank in toBankList)
            {
                transferVM.receiverBankList.Add(new SelectListItem { Value = bank.BankId.ToString(), Text = $"{bank.BankName}" });

            }
            var datas = await apiService.GetDatas(DateTime.Now.ToString("yyyy-MM-dd").ToString(), DateTime.Now.ToString("yyyy-MM-dd").ToString());
            var exchangeRate = datas.Data.Payload.SelectMany(it => it.Rates).FirstOrDefault(rate => rate.Currency.Iso3 == "MYR");
            ViewBag.ExchangeRate = exchangeRate != null ? $" {exchangeRate.Currency.Unit} NPR =  {exchangeRate.Buy} {exchangeRate.Currency.Iso3}" : string.Empty;
            if (!ModelState.IsValid)
                return View(transferVM);
            var fromBankAcc = await bankAccount.Get(it => it.AccountNumber == transferVM.senderBankAccNo && it.BankId == Int32.Parse(transferVM.senderBankName));
            if(fromBankAcc == null)
            {
                ModelState.AddModelError(string.Empty, $"Invalid Bank Acc No {transferVM.senderBankAccNo}");
                return View(transferVM);
            }
            var toBankAcc = await bankAccount.Get(it => it.AccountNumber == transferVM.receiverBankAccNo && it.BankId == Int32.Parse(transferVM.receiverBankName));
            if(toBankAcc == null)
            {
                ModelState.AddModelError(string.Empty, $"Invalid Bank Acc No {transferVM.senderBankAccNo}");
                return View(transferVM);
            }
            if (fromBankAcc.Balance < transferVM.transferAmt)
            {
                ModelState.AddModelError(string.Empty, $"Insufficient Balance for Acct No {transferVM.senderBankAccNo}");
            }
            TransactionDetails Models = new TransactionDetails
            {
                transactionDate = DateTime.Now,
                senderBankName = transferVM.senderBankName,
                senderBankAccNo = transferVM.senderBankAccNo,
                transferAmt = transferVM.transferAmt,
                ReceiverBankName = transferVM.receiverBankName,
                ReceiverBankAccNo = transferVM.receiverBankAccNo,
                ExchangeRate    = ExchangeRate,
                PayoutAmt = transferVM.amtToBeReceived,
                Id = userManager.GetUserId(User)
            };
            fromBankAcc.Balance -=  transferVM.transferAmt;
            toBankAcc.Balance += transferVM.transferAmt;
            await transactionDetails.Add(Models);
            await bankAccount.Update(fromBankAcc);
            await bankAccount.Update(toBankAcc);
            try
            {
                await transactionDetails.SaveAsync();
                await bankAccount.SaveAsync();
                TempData["Success"] = "Transaction Success";
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());
                TempData["Error"] = "Transaction Failes";
            }
            return RedirectToAction("Index", "Dashboard");

        }
    }
}
