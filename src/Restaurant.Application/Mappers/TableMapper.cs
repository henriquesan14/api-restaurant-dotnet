using AutoMapper;
using Restaurant.Application.Commands.TableCommands.CreateTable;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Mappers
{
    public class TableMapper : Profile
    {
        public TableMapper()
        {
            CreateMap<CreateTableCommand, Table>().ReverseMap();
            CreateMap<Table, TableViewModel>().ReverseMap();
        }
    }
}
