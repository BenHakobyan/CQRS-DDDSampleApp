using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampleApp.Domain;
using SampleApp.Domain.Repositories;
using SampleApp.Infrastucture;
using SampleApp.Infrastucture.Repositories;

namespace SampleApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
        {
            //dbcontext
            services.AddDbContext<ContactsContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IContactsContext, ContactsContext>();

            //repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContactRepository, ContactRepository>();

            return services;
        }
    }
}
