using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PartsGeneratorApp.Areas.Parts.DatabaseContext;
using PartsGeneratorApp.Shared.MediatR;
using PartsGeneratorApp.Shared.Middlewares;
using PartsGeneratorApp.Areas.Parts;
using FluentValidation.AspNetCore;

namespace PartsGeneratorApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("ApplicationConnection")));

            services.AddMvc()
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddControllersAsServices();
            services.AddLogging();

            services.AddScoped<IMediator, Mediator>();
            services.AddTransient<SingleInstanceFactory>(sp => t => sp.GetService(t));
            services.AddTransient<MultiInstanceFactory>(sp => t => sp.GetServices(t));

            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.ConfigureMediatR();
            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMiddleware(typeof(LoggerMiddleware));

            app.UseMvc();
        }
    }
}
