using Domain.Entities.DTOs;
using MediatR;

namespace Application.Commands
{
    public sealed class GetProductByNameCommand : IRequest<ICollection<ProductDTO>>
    {
        public string Name { get; set; }
    }
}
