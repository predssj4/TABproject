using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess
{
    public class Filters
    {
        public enum ProductFilter
        {
            [Display(Name = "Name A-Z")]
            ByNameAZ,
            [Display(Name = "Name Z-A")]
            ByNameZA,
            [Display(Name = "Product Type Name A-Z")]
            ProductTypeNameAZ,
            [Display(Name = "Product Type Name Z-A")]
            ProductTypeNameZA,
            [Display(Name = "Price Ascending")]
            PriceAsc,
            [Display(Name = "Price Descending")]
            PriceDesc
        }

        public enum StoreFilter
        {
            [Display(Name = "Id Ascending")]
            ByIdAsc ,
            [Display(Name = "Id Descending")]
            ByIdDesc ,
            [Display(Name = "Income Ascending")]
            IncomeAsc ,
            [Display(Name = "Income Descending")]
            IncomeDesc
        }

        public enum CustomerFilter
        {
            [Display(Name = "Id Ascending")]
            ByIdAsc,
            [Display(Name = "Id Descending")]
            ByIdDesc,
            [Display(Name = "Name A-Z")]
            ByNameAZ,
            [Display(Name = "Name Z-A")]
            ByNameZA,
            [Display(Name = "Lastname A-Z")]
            ByLastNameAZ,
            [Display(Name = "Lastname Z-A")]
            ByLastNameZA,
            [Display(Name = "Birthdate Ascending")]
            ByBirthDateAsc,
            [Display(Name = "Birthdate Descending")]
            ByBirthDateDesc,
            [Display(Name = "Address A-Z")]
            ByAddressAZ,
            [Display(Name = "Address Z-A")]
            ByAddressZA
        }

        public enum DiscountFilter
        {
            [Display(Name = "Id Ascending")]
            ByIdAsc,
            [Display(Name = "Id Descending")]
            ByIdDesc,
            [Display(Name = "Name A-Z")]
            ByNameAZ,
            [Display(Name = "Name Z-A")]
            ByNameZA,
            [Display(Name = "Value Ascending")]
            ByValueAsc,
            [Display(Name = "Value Descending")]
            ByValueDesc,
        }
    }
   

}
