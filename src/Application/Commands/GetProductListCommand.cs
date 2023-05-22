using Domain.Entities.DTOs;
using MediatR;

namespace Application.Commands
{
    public sealed class GetProductListCommand : IRequest<ICollection<ProductDTO>>
    {
    }
}
