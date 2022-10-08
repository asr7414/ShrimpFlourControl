using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimpFlourControl.Products
{
    /// <summary>
    /// 產品工序
    /// </summary>
    public class ProductOperaction
    {
        public int ProductID { get; set; }
        /// <summary>
        /// 機台StationId
        /// </summary>
        public int StationId { get; set; }
        /// <summary>
        /// 工序作業時間
        /// </summary>
        public int OperactionTime { get;set; }
    }
}
