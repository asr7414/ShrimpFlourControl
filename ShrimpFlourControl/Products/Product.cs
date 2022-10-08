using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimpFlourControl.Products
{
    /// <summary>
    /// 產品
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 產品ID
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 產品名
        /// </summary>
        public string Name { get; set; }   
        /// <summary>
        /// 產品工序順序
        /// </summary>
        public List<ProductOperaction> ProductOperactionList { get; set; }
    }
}
