using LogixTest.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogixTest.Infrastructure
{
    public static class RepositoryRegistration
    {
        public static void AddInfratructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IMovieRepository, MovieRepository>();
        }
    }
}
