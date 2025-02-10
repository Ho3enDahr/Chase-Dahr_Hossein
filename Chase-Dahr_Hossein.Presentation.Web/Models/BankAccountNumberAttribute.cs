using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Chase_Dahr_Hossein.Presentation.Web.Models
{
    public class BankAccountNumberAttribute: ValidationAttribute
    {
        private static readonly Regex BankAccountRegex = new Regex(@"((\\d{4})-){3}\\d{4}");

        public BankAccountNumberAttribute() : base("Invalid bank account number (0000-0000-0000-0000)") { }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            string[] splited = value.ToString().Split('-');
            return splited.All(a => a.Length == 4) && !splited.Any(a => a.Any(b => b < 48 || b > 57));
        }
    }
}
