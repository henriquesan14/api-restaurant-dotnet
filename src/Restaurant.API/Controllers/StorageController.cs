using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Controllers.Base;
using Restaurant.Application.Commands.StorageCommands.DeleteFile;
using Restaurant.Application.Commands.StorageCommands.UploadFile;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StorageController : BaseController
    {
        private readonly IMediator _mediator;

        public StorageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] UploadFileCommand command, [FromQuery] string folderName)
        {
            command.FolderName = folderName;
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteFileCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }
    }
}
