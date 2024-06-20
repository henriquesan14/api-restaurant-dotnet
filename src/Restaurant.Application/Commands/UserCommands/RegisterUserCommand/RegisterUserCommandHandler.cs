﻿using AutoMapper;
using MediatR;
using Restaurant.Core.Entities;
using Restaurant.Core.Exceptions;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.UserCommands.RegisterUserCommand
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            User userExist = await _userRepository.GetByEmail(request.Email);
            if (userExist != null)
            {
                throw new UserAlreadyExistsException("Já possui um usuário com este email");
            }
            var addresses = new List<Address>() {
                new Address
                {
                    Street = request.Street,
                        Number = request.Number,
                    District = request.District,
                    ZipCode = request.ZipCode,
                    CreatedAt = DateTime.Now
                }
            };
            
            request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password, 8);
            var user = _mapper.Map<User>(request);
            user.Addresses = addresses;
            var userCreated = await _userRepository.AddAsync(user);
            return userCreated.Id;
        }
    }
}
