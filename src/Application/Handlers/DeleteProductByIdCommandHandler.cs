using Application.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Handlers
{
    internal sealed class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, bool>
    {
        private readonly IUnitOfWork _uof;

        public DeleteProductByIdCommandHandler(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var id = request.Id;
                _uof.ProductRepository.DeleteById(id);
                await _uof.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }
    }
}
