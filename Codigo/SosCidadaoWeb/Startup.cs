using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service;

namespace SosCidadaoWeb
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
            services.AddControllersWithViews();
            //inje��o depend�ncia DBContext
            services.AddDbContext<SosCidadaoContext>(options =>
                options.UseMySQL(
                    Configuration.GetConnectionString("SosCidadaoConnection")));

            //inje��o de dependencia de servi�os
            services.AddTransient<IComentarioService, ComentarioService>();
            services.AddTransient<ITipopertenceService, TipopertenceService>();
            services.AddTransient<ITipoocorrenciaService, TipoocorrenciaService>();
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IPertenceService, PertenceService>();
            services.AddTransient<IOrganizacaoService, OrganizacaoService>();
            services.AddTransient<ILocalService, LocalService>();
            services.AddTransient<IOcorrenciaService, OcorrenciaService>();


            services.AddAutoMapper(typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
