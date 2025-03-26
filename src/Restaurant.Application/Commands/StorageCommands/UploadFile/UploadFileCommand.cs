using MediatR;
using Microsoft.AspNetCore.Http;
using Restaurant.Core.Common;
using Restaurant.Core.Response;

namespace Restaurant.Application.Commands.StorageCommands.UploadFile
{
    public class UploadFileCommand : IRequest<Result<UploadResponse>>
    {
        public IFormFile FormFile { get; set; }

        public string? FolderName { get; set; }
    }
}
