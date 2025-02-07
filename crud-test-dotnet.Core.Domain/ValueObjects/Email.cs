using System.Text.RegularExpressions;

namespace crud_test_dotnet.Core.Domain.ValueObjects
{
    public  record Email
    {
        public string Value { get;  }
        public Email(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new ArgumentNullException("email address connot be empty");
            bool validEmail = Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!validEmail)
                throw new ArgumentException("email address is not valid");
            Value = value;
        }
        private Email()
        {
            
        }
    }
}
