using Application.Common.Dtos;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
	public class GetAllAdminsQuery : IRequest<List<UserDto>>
	{

		public class GetAllAdminsQueryHandler : IRequestHandler<GetAllAdminsQuery, List<UserDto>>
		{	
			private readonly IAcademyDbContext _dbContext;
			private readonly IMapper _mapper;
			public GetAllAdminsQueryHandler(IAcademyDbContext dbContext, IMapper mapper)
			{
				_dbContext= dbContext;
				_mapper= mapper;
			}

			public async Task<List<UserDto>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
			{
				var admins = await _dbContext.Users
									.Where(x=>x.Roles.Any(r=>r.Id == 1))
									.ToListAsync();

				return _mapper.Map<List<UserDto>>(admins);
			}
		}
	}
}
