using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class Order
    {
        public int Id { get; set; }

        public string CustomerCnic { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartShift { get; set; }
        public string EndShift { get; set; }
        public string Status { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public string Remarks { get; set; }
        public List<OrderProduct> ProductList { get; set; }
    }
}