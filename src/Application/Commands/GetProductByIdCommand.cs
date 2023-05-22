using Domain.Entities.DTOs;
using MediatR;

namespace Application.Commands
{
    public sealed class GetProductByIdCommand : IRequest<ProductDTO>
    {
        public Guid Id { get; set; }
    }
}
