using IBusiness;
using IRepository;
using Model.TableModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository iProductRepository;
        public ProductBusiness(IProductRepository productRepository)
        {
            iProductRepository = productRepository;
        }
        /// <summary>
        /// 创建单个产品
        /// </summary>
        /// <param name="entity">产品</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool CreateEntity(Product entity, string connectionString = null)
        {
            return iProductRepository.CreateEntity(entity, connectionString);
        }
        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entityList">产品集合</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool CreateEntityList(IEnumerable<Product> entityList, string connectionString = null)
        {
            return iProductRepository.CreateEntityList(entityList, connectionString);
        }
        /// <summary>
        /// 根据主键Id删除一个产品
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool DeleteEntityById(int id, string connectionString = null)
        {
            return iProductRepository.DeleteEntityById(id, connectionString);
        }
        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public IEnumerable<Product> RetriveAllEntity(string connectionString = null)
        {
            return iProductRepository.RetriveAllEntity(connectionString);
        }
        /// <summary>
        /// 根据主键Id获取一个产品
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public Product RetriveOneEntityById(int id, string connectionString = null)
        {
            return iProductRepository.RetriveOneEntityById(id, connectionString);
        }
        /// <summary>
        /// 修改一个产品
        /// </summary>
        /// <param name="entity">要修改的产品</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool UpdateEntity(Product entity, string connectionString = null)
        {
            return iProductRepository.UpdateEntity(entity, connectionString);
        }
    }
}
