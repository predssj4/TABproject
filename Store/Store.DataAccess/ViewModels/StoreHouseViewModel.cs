using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.ViewModels
{
    public class StoreHouseViewModel
    {
        public int StoreHouseId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Voivodeship { get; set; }

        public bool Selected { get; set; }
    }
}
