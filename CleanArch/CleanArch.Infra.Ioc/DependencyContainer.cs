using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Application Layer
            services.AddScoped<CourseService, CourseService>();
            #endregion

            #region Infra.Data Layer
            services.AddScoped<ICourseRepository, CourseRepository>();

            #endregion           
        }
    }
}
