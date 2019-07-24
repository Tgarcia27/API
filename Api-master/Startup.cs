using TriscalWebApi.Context;
using TriscalWebApi.Interface;
using TriscalWebApi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace TriscalWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ClienteContext>(o => o.UseSqlServer(this.Configuration.GetConnectionString("DbCliente")));
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Documentação API - Triscal",
                        Version = "v1",
                        Description = "Projeto de demonstração ASP.Net Core",
                        Contact = new Contact
                        {
                            Name = "Thiago Garcia Siqueira",
                            Url = "https://github.com/wellingtonjhn"
                        }
                    });
            });

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
             app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Documentação API - Triscal");
            });

            app.UseHttpsRedirection();
            app.UseMvc();



           
        }
    }
}
