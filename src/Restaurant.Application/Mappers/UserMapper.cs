using AutoMapper;
using Restaurant.Application.Commands.UserCommands.CreateUserCommand;
using Restaurant.Application.Commands.UserCommands.RegisterUserCommand;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
        }
    }
}
