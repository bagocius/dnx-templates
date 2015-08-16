using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;

namespace app_aspnet_static_min {
  public class Startup {

    // Application entry point.
    public Startup(IHostingEnvironment env) {

    }

    // Add and configure middleware.
    public void ConfigureServices(IServiceCollection services) {

    }

    // Configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app) {
      app.UseStaticFiles()
      .UseFileServer();
    }

  }
}