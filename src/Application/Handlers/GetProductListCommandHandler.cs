using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.DTOs;
using MediatR;

namespace Application.Handlers
{
    internal sealed class GetProductListCommandHandler : IRequestHandler<GetProductListCommand, ICollection<ProductDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;

        public GetProductListCommandHandler(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public Task<ICollection<ProductDTO>?>? Handle(GetProductListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productList = _uof.ProductRepository.Get().ToList();

                if (productList is not null)
                {
                    var productDtoList = _mapper.Map<ICollection<ProductDTO>>(productList);
                    return Task.FromResult(productDtoList);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }
    }
}
