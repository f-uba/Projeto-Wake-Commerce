using Domain.Entities.DTOs;
using Domain.Enums;
using MediatR;

namespace Application.Commands
{
    public sealed class GetProductListOrderByPropertyCommand : IRequest<ICollection<ProductDTO>>
    {
        public OrderByFilterEnum filter { get; set; }
    }
}
