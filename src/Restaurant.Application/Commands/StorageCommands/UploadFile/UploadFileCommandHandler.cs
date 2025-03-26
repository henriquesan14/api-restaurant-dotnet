using MediatR;
using Restaurant.Core.Common;
using Restaurant.Core.Response;
using Restaurant.Core.Services;

namespace Restaurant.Application.Commands.StorageCommands.UploadFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, Result<UploadResponse>>
    {
        private IStorageService _uploadService;

        public UploadFileCommandHandler(IStorageService uploadService)
        {
            _uploadService = uploadService;
        }

        public async Task<Result<UploadResponse>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var uploadRequest = new Core.Request.UploadRequest(request.FormFile.FileName, request.FolderName, request.FormFile.OpenReadStream(), request.FormFile.ContentType);
            var result = await _uploadService.Save(uploadRequest);
            return Result<UploadResponse>.Success(result);
        }
    }
}
