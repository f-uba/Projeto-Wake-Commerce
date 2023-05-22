using Domain.Entities.Models;

namespace Application.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product? GetById(Guid id);
        void DeleteById(Guid id);
    }
}
