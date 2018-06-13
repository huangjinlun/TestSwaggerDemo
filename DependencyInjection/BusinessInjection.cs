using Business;
using IBusiness;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    /// <summary>
    /// 注入业务逻辑层
    /// </summary>
    public class BusinessInjection
    {
        public static void ConfigureBusiness(IServiceCollection services)
        {
            services.AddSingleton<IUserBusiness, UserBusiness>();
            services.AddSingleton<IProductBusiness, ProductBusiness>();
        }
    }
}
