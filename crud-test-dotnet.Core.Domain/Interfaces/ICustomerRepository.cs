using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;

namespace crud_test_dotnet.Core.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> AddAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task<Customer> DeleteAsync(Guid id);
        Task<Customer> GetByIdAsync(Guid Id);
        Task<Customer> GetByEmailAsync(string email);
        Task<List<Customer>> GetAllAsync();
        Task<int> CommitAsync();
    }
}
