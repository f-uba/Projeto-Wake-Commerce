using MediatR;

namespace Application.Commands
{
    public sealed class DeleteProductByIdCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
