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
            bool validbankAccount = Regex.IsMatch(value, @"[a-zA-Z]{2}[0-9]{2}[a-zA-Z0-9]{4}[0-9]{7}([a-zA-Z0-9]?){0,16}", RegexOptions.IgnoreCase);
            if (!validbankAccount)
                throw new ArgumentException("bank account number is not valid");
            Value = value;
        }
        private BankAccountNumber()
        {
            
        }
    }
   
}
