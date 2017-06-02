using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public string StoreName { get; set; }

        public string PaymentType { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderSum { get; set; }

    }
}
