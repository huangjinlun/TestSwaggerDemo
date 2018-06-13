using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.TableModel;

namespace TestSwaggerDemo.Controllers
{
    /// <summary>
    /// 产品控制器
    /// </summary>
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductBusiness iProductBusiness;
        /// <summary>
        /// 产品构造函数注入服务
        /// </summary>
        /// <param name="productBusiness"></param>
        public ProductController(IProductBusiness productBusiness)
        {
            iProductBusiness = productBusiness;
        }

        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Product> GetAllUser()
        {
            return iProductBusiness.RetriveAllEntity().OrderBy(m => m.Id);
        }


        /// <summary>
        /// 根据主键Id获取一个 产品
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Product GetOneUser(int id)
        {
            return iProductBusiness.RetriveOneEntityById(id);
        }

        /// <summary>
        /// 新增产品
        /// </summary>
        /// <param name="product">产品实体</param>
        /// <returns></returns>
        [HttpPost]
        public bool CreateProduct([FromBody]Product product)
        {
            List<Product> productList = new List<Product>();
            //for (int i = 0; i < 5000; i++)
            //{
            //    productList.Add(new Product
            //    {
            //        ProductName = "vivo x2",
            //        Brand = "brand vivo",
            //        ProductPrice = 1000,
            //        CreateDate = DateTime.Now,
            //        CreateUserId =100,
            //        UpdateDate = DateTime.Now,
            //        UpdateUserId = 100,
            //        IsDeleted = false
            //    });
            //}

            //iProductBusiness.CreateEntityList(productList);
            return iProductBusiness.CreateEntity(product);
        }

        /// <summary>
        /// 修改产品
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="product">产品实体</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public bool UpdateUser(int id, [FromBody]Product product)
        {
            product.Id = id;
            return iProductBusiness.UpdateEntity(product);
        }

        /// <summary>
        /// 根据主键Id删除一个产品
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public bool DeleteProduct(int id)
        {
            return iProductBusiness.DeleteEntityById(id);
        }
    }
}