using Application.Common.Dtos;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
	public class GetTestRecordsQuery : IRequest<List<TestDto>>
	{
		public class GetTestRecordsQueryHandler : IRequestHandler<GetTestRecordsQuery, List<TestDto>>
		{
			private readonly IAcademyDbContext _academyDbContext;
			private readonly IMapper _mapper;

			public GetTestRecordsQueryHandler(IAcademyDbContext academyDbContext, IMapper mapper)
			{
				_academyDbContext = academyDbContext;
				_mapper = mapper;
			}

			public async Task<List<TestDto>> Handle(GetTestRecordsQuery request, CancellationToken cancellationToken)
			{
				var test = await _academyDbContext.Tests.ToListAsync(cancellationToken);

				var testDto = _mapper.Map<List<TestDto>>(test);

				return testDto;
			}
		}
	}
}
