using Domain.Entities.Models;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace WakeCommercexUnitTests
{
    public sealed class DBUnitTestsMockInitializer
    {
        private readonly AppDbContext _context;

        public DBUnitTestsMockInitializer(AppDbContext context)
        {
            _context = context;
            _context.Database.Migrate();
        }

        public void Seed()
        {
            _context.Products.Add
                (new Product { Id = Guid.NewGuid(), Name = "Gibi Monica", Stock = 10, Value = 10.0 });

            _context.Products.Add
                (new Product { Id = Guid.NewGuid(), Name = "Gibi Magali", Stock = 20, Value = 20.0 });

            _context.Products.Add
                (new Product { Id = Guid.NewGuid(), Name = "Gibi Cebolinha", Stock = 30, Value = 30.0 });

            _context.Products.Add
                (new Product { Id = new Guid("a9000eec-769b-46cc-82f3-8f9496123e49"), Name = "Gibi Cascão", Stock = 40, Value = 40.0 });

            _context.Products.Add
                (new Product { Id = new Guid("6d7f547c-8899-45ef-ad53-6b0c59a37589"), Name = "Gibi Chico Bento", Stock = 50, Value = 50.0 });
        }
    }
}
