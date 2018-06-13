using IRepository;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.MySQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    /// <summary>
    /// 注入仓储层
    /// </summary>
    public class RepositoryInjection
    {
        public static void ConfigureRepository(IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            // services.AddSingleton<IUserRepository, UserRepositoryMySql>();
        }
    }
}
