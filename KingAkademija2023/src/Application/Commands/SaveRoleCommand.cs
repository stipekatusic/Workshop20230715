using Application.Common.Dtos;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using static Application.Commands.SaveTestRecordsCommand;

namespace Application.Commands
{
    public class SaveRoleCommand : IRequest<RoleDto>
    {
        public RoleDto RoleDto { get; set; }

        public class SaveRoleCommandHandler : IRequestHandler<SaveRoleCommand, RoleDto>
        {
            private readonly IAcademyDbContext _academyDbContext;
            private readonly IMapper _mapper;
            private readonly ILogger<SaveRoleCommandHandler> _logger;

            public SaveRoleCommandHandler(IAcademyDbContext academyDbContext, IMapper mapper, ILogger<SaveRoleCommandHandler> logger)
            {
                _academyDbContext = academyDbContext;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<RoleDto> Handle(SaveRoleCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var role = _mapper.Map<Role>(request.RoleDto);

                    await _academyDbContext.Roles.AddAsync(role, cancellationToken);

                    await _academyDbContext.SaveChangesAsync(cancellationToken);

                    var roleDto = _mapper.Map<RoleDto>(role);

                    return roleDto;

                } catch (Exception e)
                {
                    _logger.LogError($"Error: {e.Message}");
                    throw;
                }
            }
        }
    }
}
