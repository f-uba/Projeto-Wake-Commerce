using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.DTOs;
using Domain.Entities.Models;
using MediatR;

namespace Application.Handlers
{
    public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;

        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork uof)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public async Task<ProductDTO?>? Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            ProductDTO? productDTO;
            try
            {
                productDTO = new()
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Stock = request.Stock,
                    Value = request.Value
                };

                var product = _mapper.Map<Product>(productDTO);
                _uof.ProductRepository.Update(product);
                await _uof.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }
    }
}
