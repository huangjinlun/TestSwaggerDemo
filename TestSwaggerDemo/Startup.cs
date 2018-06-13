using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace TestSwaggerDemo
{
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 配置类
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //string defaultSqlConnectionString = Configuration.GetConnectionString("SqlServerConnection");
            //string defaultMySqlConnectionString = Configuration.GetConnectionString("MySqlConnection");

            RepositoryInjection.ConfigureRepository(services);
            BusinessInjection.ConfigureBusiness(services);
            services.AddMvc();
            services.AddSwaggerGen(m =>
            {
                m.SwaggerDoc("v1", new Info
                {
                    Description = "Light System WebApi",
                    Contact = new Contact { Email = "1564557126@qq.com", Name = "huangjinlun", Url = "http://www.jiqunar.com" },
                    Version = "v1",
                    Title = "LightAPI"
                });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;//或者AppContext.BaseDirectory
                var xmlName = this.GetType().GetTypeInfo().Module.Name.Replace(".dll", ".xml").Replace(".exe", ".xml");
                var xmlPath = Path.Combine(basePath, xmlName);
                m.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc();
            app.UseSwagger(m =>
            {
                m.PreSerializeFilters.Add((swagger, http) =>
                {
                    swagger.Host = http.Host.Value;
                });
            });
            app.UseSwaggerUI(m =>
            {
               // m.RoutePrefix = "wjg";
                m.SwaggerEndpoint("/swagger/v1/swagger.json", "Light接口文档");
            });
        }
    }
}
