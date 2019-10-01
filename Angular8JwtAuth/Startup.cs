using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;

namespace Angular8JwtAuth
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors();

      services.AddMvc()
        .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore) //ignores self reference object
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1); //validate api rures

      //services.AddCors(c =>
      //{
      //  c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
      //});

      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "wwwroot";
      });

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      //app.Run(async (context) =>
      //{
      //    await context.Response.WriteAsync("Hello World!");
      //});


      //app.UseCors(options => options.AllowAnyOrigin());

      app.UseMvc();
      app.UseStaticFiles();
      app.UseSpaStaticFiles();

      app.UseSpa(spa =>
      {
        spa.Options.SourcePath = "src";

        if (env.IsDevelopment())
        {
          spa.UseAngularCliServer(npmScript: "start");
        }
      });

    }
  }
}
