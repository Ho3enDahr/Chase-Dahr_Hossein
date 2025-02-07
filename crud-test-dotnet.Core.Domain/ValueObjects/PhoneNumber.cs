using PhoneNumbers;

namespace crud_test_dotnet.Core.Domain.ValueObjects
{
    public record PhoneNumber
    {
        public string Value { get; }
        public PhoneNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("phonenumber cannot be empty");
            if (IsValidPhoneNumber(value))
                    throw new ArgumentException("invalid phone number");
            Value = value;
        }
        private PhoneNumber()
        {

        }
        public  bool IsValidPhoneNumber(string phoneNumber, string region = "US")
        {
            try
            {
                var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                var number = phoneNumberUtil.Parse(phoneNumber, region);
                return phoneNumberUtil.IsValidNumber(number);
            }
            catch (NumberParseException)
            {
                return false;
            }
        }
    }
}
