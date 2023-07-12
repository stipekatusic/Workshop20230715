using Api.Common;
using Application.Commands;
using Application.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UserController : BaseApiController
    {
        [HttpPost("save-role")]
        public async Task<IActionResult> SaveRole([FromBody] RoleDto roleDto)
        {
            return Ok(await Mediator.Send(new SaveRoleCommand() { RoleDto = roleDto }));
        }

        [HttpPost("save-user")]
        public async Task<IActionResult> SaveUser([FromBody] UserDto userDto)
        {
            return Ok(await Mediator.Send(new SaveUserCommand() { UserDto = userDto }));
        }
    }
}