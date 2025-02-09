using crud_test_dotnet.Core.Domain.Entities;
using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;
using crud_test_dotnet.Core.Domain.ValueObjects;
using crud_test_dotnet.Infrastructure.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Infrastructure.Infrastructure.DBContext
{
    public class CustomerDbContext:DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<EventStoreModel> EventStoreTable { get; set; }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(opt => {
                opt.HasKey(k => k.Id);
                //opt.HasIndex(k => new {k.FirstName,k.LastName,k.Email}).IsUnique();
                opt.HasIndex(k => k.Id).IsUnique();
               // opt.HasIndex(k => k.Email).IsUnique();
                opt.Property(c => c.BankAccountNumber).HasConversion(bankAccount=>bankAccount.Value,value=>new BankAccountNumber(value)).HasMaxLength(10).HasColumnType("varchar(10)");
                opt.Property(c=>c.Email).HasConversion(email=>email.Value,value=>new Email(value)).HasMaxLength(100);
                opt.Property(c => c.PhoneNumber).HasConversion(phone => phone.Value, value => new PhoneNumber(value)).HasMaxLength(10);
            });
            modelBuilder.Entity<EventStoreModel>(opt =>
            {
                opt.HasKey(k => k.Id);
                opt.HasIndex(k => k.Id).IsUnique();
                opt.Property(p => p.EventType).HasMaxLength(255).IsRequired();
                opt.Property(p => p.EventData).HasColumnType("nvarchar(max)").IsRequired();
                opt.Property(p => p.OccurredOn).IsRequired();
            });
        }
        //public class CustomerConfiguration: EntityTypeConfiguration<Customer>
        //{
        //    internal CustomerConfiguration()
        //    {
        //        this.ToTable("Customer");
        //        this.Property(x => x.Email.Value).HasColumnType("nvarchar(50)");
        //        this.Property(x => x.PhoneNumber.Value).HasColumnType("nvarchar(10)");
        //        this.Property(x => x.BankAccountNumber.Value).HasColumnType("nvarchar(10)");
        //    }
        //}
    }
}
