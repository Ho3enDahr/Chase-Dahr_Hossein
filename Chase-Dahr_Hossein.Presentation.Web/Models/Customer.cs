using System.ComponentModel.DataAnnotations;

namespace Chase_Dahr_Hossein.Presentation.Web.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get;  set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [BankAccountNumberAttribute]
        public string BankAccountNumber { get; set; }
    }
}
