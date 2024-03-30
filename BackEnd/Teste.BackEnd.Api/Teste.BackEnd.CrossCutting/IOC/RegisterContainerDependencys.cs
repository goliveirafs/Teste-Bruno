using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Teste.BackEnd.Application.Services;
using Teste.BackEnd.Application.Validators;
using Teste.BackEnd.Domain.Repositorys;
using Teste.BackEnd.Domain.Services;
using Teste.BackEnd.Domain.Validators;
using Teste.BackEnd.Infra.DbContext;
using Teste.BackEnd.Infra.Repositorys;

namespace Teste.BackEnd.CrossCutting.IOC
{
    public static class RegisterContainerDependencys
    {
        public static void AddBackEndDependencys(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICreditService, CreditService>();
            services.AddScoped<ICreditValidator, CreditValidator>();
            services.AddScoped<ICreditRepository, CreditRepository>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        }
    }
}
