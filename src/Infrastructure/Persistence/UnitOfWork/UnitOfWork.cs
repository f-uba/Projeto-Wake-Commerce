using Application.Interfaces;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        public AppDbContext _context;

        public IProductRepository _productRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
