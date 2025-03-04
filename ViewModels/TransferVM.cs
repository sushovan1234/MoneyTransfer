using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.ViewModels
{
    public class TransferVM
    {
        public List<SelectListItem> fromCurrencyList { get; set; } = new List<SelectListItem>();


        [Required(ErrorMessage = "From Currency is required")]
        public string fromCurrency { get; set; }

        [Required(ErrorMessage = "Transfer Amount is required")]
        public decimal transferAmt { get; set; }

        public List<SelectListItem> toCurrencyList { get; set; } = new List<SelectListItem>();

        [Required(ErrorMessage = "To Currency is required")]
        public string toCurrency { get; set; }
        [Required(ErrorMessage = "Amt To Be Received is required")]
        public decimal amtToBeReceived { get; set; }

        [Required(ErrorMessage = "Sender Bank Name is required")]
        public string senderBankName { get; set; }
        [Required(ErrorMessage = "Sender Bank Acc No is required")]
        public string senderBankAccNo { get; set; }

        [Required(ErrorMessage = "Receiver Bank Name is required")]
        public string receiverBankName { get; set; }

        [Required(ErrorMessage = "Receiver Bank Acc No is required")]
        public string receiverBankAccNo { get; set; }

        public List<SelectListItem> senderBankList { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> receiverBankList { get; set; } = new List<SelectListItem>();


    }
}
