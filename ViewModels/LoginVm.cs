using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.ViewModels
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Email cannot be empty")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool rememberMe { get; set; }

    }
}
