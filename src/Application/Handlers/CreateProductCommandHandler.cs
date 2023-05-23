using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.DTOs;
using Domain.Entities.Models;
using MediatR;

namespace Application.Handlers
{
    public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;

        public CreateProductCommandHandler(IMapper mapper, IUnitOfWork uof)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public async Task<ProductDTO?> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            ProductDTO? productDTO = null;
            try
            {
                if (Math.Sign(request.Value) >= 0)
                {
                    productDTO = new()
                    {
                        Id = Guid.NewGuid(),
                        Name = request.Name,
                        Stock = request.Stock,
                        Value = request.Value
                    };

                    var product = _mapper.Map<Product>(productDTO);
                    _uof.ProductRepository.Add(product);
                    await _uof.Commit();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return productDTO;
        }
    }
}
