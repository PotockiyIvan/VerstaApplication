using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerstaApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using VerstaApplication.Service;
using VerstaApplication.Domain.Repositories;
using VerstaApplication.Domain.Repositories.Abstract;
using VerstaApplication.Domain.Repositories.EntityFramework;

namespace VerstaApplication
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
            // подключаем конфиг из appsettings.json
            Configuration.Bind("Project", new Config());

            //Подключаем нужный функционал приложения в качестве сервисов
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddTransient<DataManager>();

            //Подключаем контекст БД в свойствах указываем что используем sql server и в качестве аргумента
            //передаем строку подключения ,которая заранее прописана в appsettings.json(чтобы не копировать ее и не ошибиться)
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            services.AddControllersWithViews();

            services.AddRazorPages();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Дефолтеый маршрут
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
