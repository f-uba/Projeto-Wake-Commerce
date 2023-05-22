using Application.Interfaces;
using Domain.Entities.Models;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    internal sealed class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public Product? GetById(Guid id)
        {
            return Get().FirstOrDefault(product => product.Id == id);
        }

        public void DeleteById(Guid id)
        {
            var product = GetById(id);
            Delete(product);
        }
    }
}
