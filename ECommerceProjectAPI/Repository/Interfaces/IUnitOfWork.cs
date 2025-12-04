using ECommerceProjectAPI.Models;
using System.Numerics;

namespace ECommerceProjectAPI.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Admin> Admins { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Branch> Branches { get; }
        IRepository<BookProduct> Books { get; }
        IRepository<PhoneProduct> Phones { get; }
        IRepository<LaptopProduct> Laptops { get; }
        IRepository<Product> Products { get; }
        IRepository<Cart> Carts { get; }
        IRepository<CartItem> CartItems { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<Address> Addresses {  get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
