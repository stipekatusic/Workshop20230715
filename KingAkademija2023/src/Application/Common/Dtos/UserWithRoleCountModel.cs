using Domain.Entities;

namespace Application.Common.Dtos
{
	public class UserWithRoleCountModel
	{
		public User User { get; set; }
		public int Count { get; set; }
	}
}
