using Application.Common.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class DependencyInjection
	{
		public static void AddInfractructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AcademyDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection"),
					b => b.MigrationsAssembly(typeof(AcademyDbContext).Assembly.FullName)));

			services.AddScoped<IAcademyDbContext>(provider => provider.GetService<AcademyDbContext>());
		}
	}
}
