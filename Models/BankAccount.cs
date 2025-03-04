namespace MoneyTransfer.Models
{
    public class BankAccount
    {
        public int AccountId { get; set; }  
        public string FirstName { get; set; }  
        public string MiddleName { get; set; } 
        public string LastName { get; set; } 
        
        public string Address { get; set; }

        public string Country { get; set; }
        public string AccountNumber { get; set; }  
        public string AccountType { get; set; }  
        public decimal Balance { get; set; } 

        public int BankId { get; set; }
        public virtual BankDetails Bank { get; set; }
    }
}
