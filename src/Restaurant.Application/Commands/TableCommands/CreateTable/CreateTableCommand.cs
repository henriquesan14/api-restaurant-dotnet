using MediatR;

namespace Restaurant.Application.Commands.TableCommands.CreateTable
{
    public class CreateTableCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
