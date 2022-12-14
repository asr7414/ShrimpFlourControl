using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimpFlourControl.Orders
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Products.Product Product { get; set; }
        public int Quantity { get; set; }   
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public Stations.Station LastStation { get; set; }
    }
}
