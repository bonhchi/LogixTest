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
        public static void AddInfratructure(this IServiceCollection services)
        {
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
        }
    }
}
