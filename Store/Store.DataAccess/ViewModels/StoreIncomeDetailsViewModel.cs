﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.ViewModels
{
    public class StoreIncomeDetailsViewModel
    {
        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }
}
