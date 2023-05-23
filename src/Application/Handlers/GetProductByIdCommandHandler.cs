using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.DTOs;
using MediatR;

namespace Application.Handlers
{
    internal sealed class GetProductByIdCommandHandler : IRequestHandler<GetProductByIdCommand, ProductDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;

        public GetProductByIdCommandHandler(IMapper mapper, IUnitOfWork uof)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public async Task<ProductDTO?>? Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var id = request.Id;
                var product = _uof.ProductRepository.GetById(id);

                if (product is not null)
                {
                    var productDto = _mapper.Map<ProductDTO>(product);
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
