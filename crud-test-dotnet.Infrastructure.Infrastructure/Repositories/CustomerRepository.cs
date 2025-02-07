using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;
using crud_test_dotnet.Core.Domain.Interfaces;
using crud_test_dotnet.Infrastructure.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace crud_test_dotnet.Infrastructure.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;
        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> AddAsync(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            await CommitAsync();
            return customer;

        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var customer = await _context.Customer.FindAsync(Id);
            if (customer == null)
                return false;
             _context.Customer.Remove(customer);
            var res = await CommitAsync();
            return  Convert.ToBoolean(res);
        }

        public  async Task<List<Customer>> GetAllAsync()
        {
           return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await _context.Customer.FirstOrDefaultAsync(c => c.Email.Value == email);
        }

        public async Task<Customer> GetByIdAsync(Guid Id)
        {
            return await _context.Customer.FindAsync(Id);
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            _context.Customer.Update(customer);
            await CommitAsync();
            return  customer;
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
