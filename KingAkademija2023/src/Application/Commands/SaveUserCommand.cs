using Application.Common.Dtos;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Application.Commands.SaveRoleCommand;

namespace Application.Commands
{
    public class SaveUserCommand : IRequest<UserDto>
    {
        public UserDto UserDto { get; set; }

        public class SaveUserCommandHandler : IRequestHandler<SaveUserCommand, UserDto>
        {
            private readonly IAcademyDbContext _academyDbContext;
            private readonly IMapper _mapper;
            private readonly ILogger<SaveUserCommandHandler> _logger;

            public SaveUserCommandHandler(IAcademyDbContext academyDbContext, IMapper mapper, ILogger<SaveUserCommandHandler> logger)
            {
                _academyDbContext = academyDbContext;
                _mapper = mapper;
                _logger = logger;
            }
            public async Task<UserDto> Handle(SaveUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _mapper.Map<User>(request.UserDto);

                    if (request.UserDto.RoleId != null)
                    {
                        var role = _academyDbContext.Roles.FirstOrDefault(x => x.Id == request.UserDto.RoleId);
                        if (role != null)
                        {
                            user.Roles.Add(role);
                        }
                    }

                    await _academyDbContext.Users.AddAsync(user, cancellationToken);

                    await _academyDbContext.SaveChangesAsync(cancellationToken);

                    var userDto = _mapper.Map<UserDto>(user);

                    return userDto;
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error: {e.Message}");
                    throw;
                }
            }
        }
    }
}
