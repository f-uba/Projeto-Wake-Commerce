using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.DTOs;
using MediatR;

namespace Application.Handlers
{
    internal sealed class GetProductByNameCommandHandler : IRequestHandler<GetProductByNameCommand, ICollection<ProductDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;

        public GetProductByNameCommandHandler(IMapper mapper, IUnitOfWork uof)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public async Task<ICollection<ProductDTO>?>? Handle(GetProductByNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string name = request.Name;

                var product = _uof.ProductRepository.Get().Where(p => p.Name == name).ToList();
                if (product.Any())
                {
                    var productDto = _mapper.Map<ICollection<ProductDTO>>(product);
                    return await Task.FromResult(productDto);
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
