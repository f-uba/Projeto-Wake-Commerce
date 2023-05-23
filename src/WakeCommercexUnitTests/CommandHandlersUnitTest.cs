using Application.Commands;
using Application.Handlers;
using Application.Interfaces;
using Application.Mapping;
using AutoMapper;
using Domain.Entities.DTOs;
using Domain.Enums;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace WakeCommercexUnitTests
{
    public sealed class CommandHandlersUnitTest
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;

        public static DbContextOptions<AppDbContext> contextOptions { get; }

        public static string connectionString =
            "Server=host.docker.internal;Port=5432;User Id=user;Password=password;Database=WakeCommerceDbTest";

        static CommandHandlersUnitTest()
        {
            contextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseNpgsql(connectionString)
                .Options;
        }

        public CommandHandlersUnitTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();

            var context = new AppDbContext(contextOptions);

            DBUnitTestsMockInitializer db = new(context);
            db.Seed();

            _uof = new UnitOfWork(context);
        }

        //=======================================================================
        // GET

        [Fact]
        public async void GetProductsList()
        {
            //Arrange
            GetProductListCommand command = new();
            GetProductListCommandHandler handler = new(_uof, _mapper);

            //Act
            var data = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsAssignableFrom<ICollection<ProductDTO>>(data);
            Assert.NotEmpty(data);
        }

        [Fact]
        public async void GetProductsOrderByName()
        {
            //Arrange
            GetProductListOrderByPropertyCommand command = new() { filter = OrderByFilterEnum.Name };
            GetProductListOrderByPropertyCommandHandler handler = new(_mapper, _uof);

            //Act
            var data = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsAssignableFrom<ICollection<ProductDTO>>(data);
            Assert.NotEmpty(data);
        }

        [Fact]
        public async void GetProductsOrderByStock()
        {
            //Arrange
            GetProductListOrderByPropertyCommand command = new() { filter = OrderByFilterEnum.Stock };
            GetProductListOrderByPropertyCommandHandler handler = new(_mapper, _uof);

            //Act
            var data = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsAssignableFrom<ICollection<ProductDTO>>(data);
            Assert.NotEmpty(data);
        }

        [Fact]
        public async void GetProductsOrderByValue()
        {
            //Arrange
            GetProductListOrderByPropertyCommand command = new() { filter = OrderByFilterEnum.Value };
            GetProductListOrderByPropertyCommandHandler handler = new(_mapper, _uof);

            //Act
            var data = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsAssignableFrom<ICollection<ProductDTO>>(data);
            Assert.NotEmpty(data);
        }

        [Fact]
        public async void GetProductById()
        {
            //Arrange
            GetProductByIdCommand command = new() { Id = new Guid("6d7f547c-8899-45ef-ad53-6b0c59a37589") };
            GetProductByIdCommandHandler handler = new(_mapper, _uof);

            //Act
            var data = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsAssignableFrom<ProductDTO>(data);
            Assert.NotNull(data);
        }

        [Fact]
        public async void GetProductsByName()
        {
            //Arrange
            GetProductByNameCommand command = new() { Name = "Gibi Chico Bento" };
            GetProductByNameCommandHandler handler = new(_mapper, _uof);

            //Act
            var data = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsAssignableFrom<ICollection<ProductDTO>>(data);
            Assert.NotEmpty(data);
        }

        //=======================================================================
        // POST

        [Fact]
        public async void PostProduct()
        {
            //Arrange
            CreateProductCommand command = new()
            {
                Name = "Gibi Franjinha",
                Stock = 60,
                Value = 60.0
            };

            CreateProductCommandHandler handler = new(_mapper, _uof);

            //Act
            var data = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsAssignableFrom<ProductDTO>(data);
            Assert.NotNull(data);
        }

        //=======================================================================
        // PUT

        [Fact]
        public async void PutProduct()
        {
            //Arrange
            UpdateProductCommand command = new()
            {
                Id = new Guid("6d7f547c-8899-45ef-ad53-6b0c59a37589"),
                Name = "Gibi Chico Bento & Rosinha",
                Stock = 51,
                Value = 51.0
            };

            UpdateProductCommandHandler handler = new(_mapper, _uof);

            //Act
            var data = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsAssignableFrom<ProductDTO>(data);
            Assert.NotNull(data);
        }

        //=======================================================================
        // DELETE

        [Fact]
        public async void DeleteProduct()
        {
            //Arrange
            DeleteProductByIdCommand command = new() { Id = new Guid("a9000eec-769b-46cc-82f3-8f9496123e49") };
            DeleteProductByIdCommandHandler handler = new(_uof);

            //Act
            var data = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(data);
        }
    }
}
