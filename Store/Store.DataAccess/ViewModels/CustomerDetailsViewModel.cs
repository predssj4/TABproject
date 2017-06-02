using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public string FullName { get; set; }

        public string Description { get; set; }

        public List<OrderViewModel> Orders { get; set; }

        public decimal SumOfOrders { get; set; }
    }
}
