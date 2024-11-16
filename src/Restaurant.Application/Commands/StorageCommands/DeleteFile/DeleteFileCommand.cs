using MediatR;
using Restaurant.Core.Common;

namespace Restaurant.Application.Commands.StorageCommands.DeleteFile
{
    public class DeleteFileCommand : IRequest<Result>
    {
        public string Path { get; set; }
    }
}
