using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.DTOs;
using Domain.Entities.Models;
using Domain.Enums;
using MediatR;

namespace Application.Handlers
{
    internal sealed class GetProductListOrderByPropertyCommandHandler : IRequestHandler<GetProductListOrderByPropertyCommand, ICollection<ProductDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;

        public GetProductListOrderByPropertyCommandHandler(IMapper mapper, IUnitOfWork uof)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public Task<ICollection<ProductDTO>?> Handle(GetProductListOrderByPropertyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filter = request.filter;
                ICollection<Product>? productList = filter switch
                {
                    OrderByFilterEnum.Name => _uof.ProductRepository.Get().OrderBy(p => p.Name).ToList(),
                    OrderByFilterEnum.Stock => _uof.ProductRepository.Get().OrderBy(p => p.Stock).ToList(),
                    OrderByFilterEnum.Value => _uof.ProductRepository.Get().OrderBy(p => p.Value).ToList(),
                    _ => _uof.ProductRepository.Get().ToList(),
                };

                var productDtoList = _mapper.Map<ICollection<ProductDTO>>(productList);
                return Task.FromResult(productDtoList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
