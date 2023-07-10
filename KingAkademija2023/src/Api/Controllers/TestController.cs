using Api.Common;
using Application.Commands;
using Application.Common.Dtos;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	public class TestController : BaseApiController
	{
		[HttpGet]
		public async Task<IActionResult> GetTest()
		{
			return Ok(await Mediator.Send(new GetTestRecordsQuery()));
		}

		[HttpPost]
		public async Task<IActionResult> SaveTest([FromBody] TestDto testDto)
		{
			return Ok(await Mediator.Send(new SaveTestRecordsCommand() { TestDto = testDto }));
		}
	}
}
