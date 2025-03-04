using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.ViewModels
{
    public class RegisterVm
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string firstName { get; set; }

        public string? middleName { get; set; }

        [Required(ErrorMessage = "lastName is required")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "email is required")]

        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Street address is required.")]
        public string street { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string city { get; set; }

        [Required(ErrorMessage = "State/Province is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "ZIP Code is required.")]
        [DataType(DataType.PostalCode)]
        public string zipCode { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string country { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Compare("password",ErrorMessage = "Password dont match")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }

    }
}
