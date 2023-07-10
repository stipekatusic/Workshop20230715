using Application.Common.Dtos;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
	public class SaveTestRecordsCommand : IRequest<TestDto>
	{
		public TestDto TestDto { get; set; }

		public class SaveTestRecordCommandHandler : IRequestHandler<SaveTestRecordsCommand, TestDto>
		{
			private readonly IAcademyDbContext _academyDbContext;
			private readonly IMapper _mapper;
			private readonly ILogger<SaveTestRecordCommandHandler> _logger;

			public SaveTestRecordCommandHandler(IAcademyDbContext academyDbContext, IMapper mapper, ILogger<SaveTestRecordCommandHandler> logger)
			{
				_academyDbContext = academyDbContext;
				_mapper = mapper;
				_logger = logger;
			}

			public async Task<TestDto> Handle(SaveTestRecordsCommand request, CancellationToken cancellationToken)
			{
				_logger.LogInformation("Inserting test");

				try
				{
					var test = _mapper.Map<Test>(request.TestDto);

					await _academyDbContext.Tests.AddAsync(test, cancellationToken);

					await _academyDbContext.SaveChangesAsync(cancellationToken);

					var testDto = _mapper.Map<TestDto>(test);

					return testDto;
				}
				catch (Exception e)
				{
					_logger.LogError($"Error inserting test: {e.Message}");
					throw;
				}
			}
		}

	}
}
