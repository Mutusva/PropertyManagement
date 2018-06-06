
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PropertyManagement.Repository.Concretes;
using PropertyManagement.Repository.Context;
using PropertyManagement.Repository.Interfaces;
using PropertyManagement.service;

namespace PropertyManagement.UI
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
      services.AddMvc();
      services.AddDbContext<PropertyManagementContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PropertyManagementContext")));
      services.AddTransient<IPropertyDetailRepository, PropertyDetailRepository>();
      services.AddTransient<IOwnerHistoryRepository, OwnerHistoryRepository>();
      services.AddTransient<IPropertyImageRepository, PropertyImageRepository>();

      services.AddTransient<IOwnerHistoryService, OwnerHistoryService>();
      services.AddTransient<IPropertyImageService, PropertyImageService>();
      services.AddTransient<IPropertyDetailService, PropertyDetailService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseBrowserLink();
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
