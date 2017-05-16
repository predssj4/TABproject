using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.ViewModels
{
    public class StoreViewModel
    {
        public int StoreId { get; set; }

        public string Name { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Voivodeship { get; set; }

        public int AmountOfStoreHouses { get; set; }
    }
}
