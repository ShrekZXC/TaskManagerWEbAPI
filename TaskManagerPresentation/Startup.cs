using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManagerBLL;
using TaskManagerBLL.Interfaces;
using TaskManagerDAL;
using TaskManagerDAL.Interfaces;
using TaskManagerDAL.Repositories;
using TaskManagerMapping;

namespace TaskManagerPresentation
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
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TaskManagerMappingProfile>();
            });
            services.AddSingleton(mappingConfig.CreateMapper());

            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IStatusService, StatusService>();
            services.AddTransient<IStatusRepository, StatusRepository>();

            services.AddDbContext<TaskManagerContext>(
                options => options.UseMySql("server=localhost;database=taskdb;uid=root;pwd=123zxc456vbnSS"));
            services.AddControllersWithViews();
            services.AddMvc();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Tasks}/{action=Index}/{id?}");
            });
        }
    }
}
