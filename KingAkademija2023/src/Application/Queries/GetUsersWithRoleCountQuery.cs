using Application.Common.Dtos;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
	public class GetUsersWithRoleCountQuery : IRequest<List<UserWithRoleCountViewModel>>
	{
		public class GetUsersWithRoleCountQueryHandler : IRequestHandler<GetUsersWithRoleCountQuery, List<UserWithRoleCountViewModel>>
		{
			private readonly IAcademyDbContext _dbContext;

			public GetUsersWithRoleCountQueryHandler(IAcademyDbContext dbContext)
			{
				_dbContext= dbContext;
			}

			public async Task<List<UserWithRoleCountViewModel>> Handle(GetUsersWithRoleCountQuery request, CancellationToken cancellationToken)
			{
				return await _dbContext.Users
						.Include(r=>r.Roles)
						.Select(x => new UserWithRoleCountViewModel
						{
							User = x,
							Count = x.Roles.Count()
						})
						.ToListAsync();
			}
		}
	}
}
