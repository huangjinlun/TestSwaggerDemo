using System;
using System.Collections.Generic;
using System.Text;

namespace Model.TableModel
{
    /// <summary>
    /// 产品实体
    /// </summary>
    public class Product : BaseModel
    {
        /// <summary>
        /// 产品名
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 产品价格
        /// </summary>
        public decimal ProductPrice { get; set; }
    }
}
