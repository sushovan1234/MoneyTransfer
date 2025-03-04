namespace MoneyTransfer.Models
{
    public class ReportModel
    {
        public SenderDetails SenderDetails { get; set; } = new SenderDetails();

        public ReceiverDetails ReceiverDetails { get; set; } = new ReceiverDetails();
        public string SenderBankName { get; set; }

        public string SenderAcctNo { get; set; }

        public string ReceiverBankName { get; set; }

        public string ReceiverAcctNo { get; set; }

        public decimal TransferAmount { get; set; }

        public string ExchangeRate { get; set; }

        public decimal PayoutAmount { get; set; }

        public DateTime TransactionDate { get; set; }

    }

    public class SenderDetails
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public string Country { get; set; }
    }

    public class ReceiverDetails
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public string Country { get; set; }
    }
}
