using System.Text.RegularExpressions;

namespace crud_test_dotnet.Core.Domain.ValueObjects
{
    public record BankAccountNumber
    {
        public string Value { get; }
        public BankAccountNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("bank account number connot be empty");
            var BankAccountRegex = new Regex(@"((\\d{4})-){3}\\d{4}");
            string[] splited = value.ToString().Split('-');
            bool validbankAccount= splited.All(a => a.Length == 4) && !splited.Any(a => a.Any(b => b < 48 || b > 57));
            if (!validbankAccount)
                throw new ArgumentException("invalid bank account number");
            Value = value;
        }
        private BankAccountNumber()
        {
            
        }
    }
   
}
