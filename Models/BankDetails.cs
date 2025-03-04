namespace MoneyTransfer.Models
{
    public class BankDetails
    {
        public int BankId { get; set; }  
        public string BankName { get; set; }  
        public string Country { get; set; }  
        public string IsoCode { get; set; } 
        
        public string Currency { get; set; }
        public string SwiftCode { get; set; }  
        public string Address { get; set; } 

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
