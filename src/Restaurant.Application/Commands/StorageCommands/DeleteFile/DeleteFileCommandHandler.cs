using MediatR;
using Restaurant.Core.Common;
using Restaurant.Core.Services;

namespace Restaurant.Application.Commands.StorageCommands.DeleteFile
{
    public class DeleteStorageFileCommandHandler : IRequestHandler<DeleteFileCommand, Result>
    {
        private IStorageService _storageService;

        public DeleteStorageFileCommandHandler(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<Result> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            await _storageService.Delete(request.Path);
            return Result.NoContent();
        }
    }
}
