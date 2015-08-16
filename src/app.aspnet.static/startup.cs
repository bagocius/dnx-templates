using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Runtime;

namespace app_aspnet_static {
  public class Startup {
    
    public IConfiguration config { get; set; }

    // Application entry point.
    public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv) {
      // Source and build configuration settings.
      config = new ConfigurationBuilder(appEnv.ApplicationBasePath)
        .AddJsonFile("config/app.json")
        .AddJsonFile($"config/env.{env.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables()
        .Build();
      // Configure Logging.
      Serilog.Log.Logger = new Serilog.LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.TextWriter(Console.Out)
        .CreateLogger();
    }

    // Add and configure middleware.
    public void ConfigureServices(IServiceCollection services) {
      
    }

    // Configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
      switch (config["ASPNET_ENV"].ToLower()) {
        case "dev":
        case "development":
          loggerFactory.AddSerilog();
          app.UseErrorPage(new ErrorPageOptions() { SourceCodeLineCount = 10 });
          app.UseBrowserLink();
          break;
        case "stage":
        case "staging":
          app.UseErrorHandler("/error.html");
          break;
        case "prod":
        case "production":
          app.UseErrorHandler("/error.html");
          break;
      }
      app.UseStaticFiles()
        .UseFileServer();
    }

  }
}