using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.Models
{
    public class User : IdentityUser
    {
        public string? firstName { get; set; }

        public string? middleName { get; set; }
        public string? lastName { get; set; }
        public string? formattedAddress { get; set; }

        public ICollection<TransactionDetails> TransactionDetails { get; set; }
    }
}
