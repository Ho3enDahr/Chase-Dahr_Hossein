using Chase_Dahr_Hossein.Presentation.Web.Models;

namespace Chase_Dahr_Hossein.Presentation.Web.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;
        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Customer>> GetCustomers()
        {
            return await _httpClient.GetFromJsonAsync<List<Customer>>("Customer/GetCustomers");
        }
        public async Task<Customer> GetCustomer(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Customer>($"Customer/GetCustomerById?id={id}");
        }

        public async Task CreateCustomer(Customer customer)
        {
            await _httpClient.PostAsJsonAsync("Customer/CreateCustomer", customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await _httpClient.PostAsJsonAsync($"Customer/UpdateCustomer", customer);
        }

        public async Task DeleteCustomer(Guid id)
        {
            await _httpClient.DeleteAsync($"Customer/DeleteCustomer?id={id}");
        }
    }
}
