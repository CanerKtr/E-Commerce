using ECommerceProjectAPI.Models;
using ECommerceProjectAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Numerics;
using ECommerceProjectAPI.Data;

namespace ECommerceProjectAPI.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        public IRepository<Admin> Admins { get;}
        public IRepository<Customer> Customers { get; }
        public IRepository<Employee> Employees { get; }
        public IRepository<Branch> Branches { get; }
        public IRepository<BookProduct> Books { get; }
        public IRepository<PhoneProduct> Phones { get; }
        public IRepository<LaptopProduct> Laptops { get; }
        public IRepository<Product> Products { get; }
        public IRepository<Cart> Carts { get; }
        public IRepository<CartItem> CartItems { get; }
        public IRepository<Order> Orders { get; }
        public IRepository<OrderItem> OrderItems { get; }
        public IRepository<Address> Addresses { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Admins = new Repository<Admin>(_context);
            Customers = new Repository<Customer>(_context);
            Employees = new Repository<Employee>(_context);
            Branches = new Repository<Branch>(_context);
            Books = new Repository<BookProduct>(_context);
            Phones = new Repository<PhoneProduct>(_context);
            Laptops = new Repository<LaptopProduct>(_context);
            Products = new Repository<Product>(_context);
            Carts = new Repository<Cart>(_context);
            CartItems = new Repository<CartItem>(_context);
            Orders = new Repository<Order>(_context);
            OrderItems = new Repository<OrderItem>(_context);
            Addresses = new Repository<Address>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}

