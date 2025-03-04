using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.Models;
using MoneyTransfer.Services.Interface;

namespace MoneyTransfer.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {

        private readonly ITransactionDetails transactionDetails;
        private readonly IBankAccount bankAccount;
        private readonly UserManager<User> userManager;
        public ReportController(IBankAccount bankAccount,ITransactionDetails transactionDetails,UserManager<User> userManager)
        {
            this.bankAccount = bankAccount;
            this.transactionDetails = transactionDetails;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
           
            var currentuser = userManager.GetUserId(User);
            var TransactionDetails = await transactionDetails.GetAll(it => it.Id == currentuser);
            var BankAccountDetails = await bankAccount.GetAll();
            var list = new List<ReportModel>();
            foreach (var items in TransactionDetails)
            {
                var Model = new ReportModel();
                Model.SenderBankName = items.senderBankName;
                Model.SenderAcctNo = items.senderBankAccNo;
                Model.TransferAmount = items.transferAmt;
                Model.PayoutAmount = items.PayoutAmt;
                Model.TransactionDate = items.transactionDate;
                Model.ReceiverBankName = items.ReceiverBankName;
                Model.ReceiverAcctNo = items.ReceiverBankAccNo;
                var SenderBankAcc = BankAccountDetails.Where(it => it.AccountNumber == items.senderBankAccNo).FirstOrDefault();
                var ReceiverBankAcc = BankAccountDetails.Where(it => it.AccountNumber == items.ReceiverBankAccNo).FirstOrDefault();
                if (SenderBankAcc != null)
                {
                    var SenderDetailsModel = new SenderDetails
                    {
                        FirstName = SenderBankAcc.FirstName,
                        LastName = SenderBankAcc.LastName,
                        Country = SenderBankAcc.Country,
                        Address = SenderBankAcc.Address
                    };
                    Model.SenderDetails = SenderDetailsModel;
                }
                if (ReceiverBankAcc != null)
                {
                    var ReceiverDetailsModel = new ReceiverDetails
                    {
                        FirstName = ReceiverBankAcc.FirstName,
                        LastName = ReceiverBankAcc.LastName,
                        Country = ReceiverBankAcc.Country,
                        Address = ReceiverBankAcc.Address
                    };
                    Model.ReceiverDetails = ReceiverDetailsModel;
                }
                list.Add(Model);
            }
            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> Index(DateTime fromdate,DateTime toDate)
        {
            ViewBag.fromDate = fromdate.Date.ToString("yyyy-MM-dd");
            ViewBag.toDate = toDate.Date.ToString("yyyy-MM-dd");
            var currentuser = userManager.GetUserId(User);
            var TransactionDetails = await transactionDetails.GetAll(it => it.Id == currentuser && it.transactionDate.Date >= fromdate.Date && 
            it.transactionDate.Date <= toDate.Date);
            var BankAccountDetails = await bankAccount.GetAll();
            var list = new List<ReportModel>();
            foreach (var items in TransactionDetails)
            {
                var Model = new ReportModel();
                Model.SenderBankName = items.senderBankName;
                Model.SenderAcctNo = items.senderBankAccNo;
                Model.TransferAmount = items.transferAmt;
                Model.PayoutAmount = items.PayoutAmt;
                Model.TransactionDate = items.transactionDate;
                var SenderBankAcc = BankAccountDetails.Where(it => it.AccountNumber == items.senderBankAccNo).FirstOrDefault();
                var ReceiverBankAcc = BankAccountDetails.Where(it => it.AccountNumber == items.ReceiverBankAccNo).FirstOrDefault();
                if (SenderBankAcc != null)
                {
                    var SenderDetailsModel = new SenderDetails
                    {
                        FirstName = SenderBankAcc.FirstName,
                        LastName = SenderBankAcc.LastName,
                        Address = SenderBankAcc.Address
                    };
                    Model.SenderDetails = SenderDetailsModel;
                }

                if (ReceiverBankAcc != null)
                {
                    var ReceiverDetailsModel = new ReceiverDetails
                    {
                        FirstName = ReceiverBankAcc.FirstName,
                        LastName = ReceiverBankAcc.LastName,
                        Address = ReceiverBankAcc.Address
                    };
                    Model.ReceiverDetails = ReceiverDetailsModel;
                }
                list.Add(Model);
            }
            return View(list);
        }

    }
}
