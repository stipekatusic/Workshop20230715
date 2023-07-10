using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Common
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseApiController : ControllerBase
	{
		private IMediator mediator;

		protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
	}
}
