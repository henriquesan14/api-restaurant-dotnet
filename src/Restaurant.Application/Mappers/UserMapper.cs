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
            CreateMap<User, UserViewModel>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<RegisterUserCommand, User>();
        }
    }
}
