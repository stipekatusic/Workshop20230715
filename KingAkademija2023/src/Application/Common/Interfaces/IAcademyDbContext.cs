using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
	public interface IAcademyDbContext
	{
		public DbSet<Test> Tests { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
