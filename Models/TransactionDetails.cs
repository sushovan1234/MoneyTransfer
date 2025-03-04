using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.Models
{
    public class TransactionDetails
    {
        public int transactionId { get; set; }

        public DateTime transactionDate { get; set; }

        public string senderBankName { get; set; }

        public string senderBankAccNo { get; set; }

        public decimal transferAmt { get; set; }
        public string ReceiverBankName { get; set; }
        public string ReceiverBankAccNo { get; set; }

        public string ExchangeRate { get; set; }

        public decimal PayoutAmt { get; set; }

        public string Id { get; set; }
        public User User { get; set; }
    }
}
