﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.ViewModels
{
    public class StoreIncomeViewModel
    {
        public int StoreId { get; set; }

        public string Name { get; set; }

        public decimal Income { get; set; }
    }
}
