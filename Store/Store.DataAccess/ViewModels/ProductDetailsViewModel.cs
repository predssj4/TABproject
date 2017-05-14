namespace Store.DataAccess.ViewModels
{
    public class ProductDetailsViewModel : ProductViewModel
    {
        public int HowManyTimesOrdered { get; set; }

        public decimal SumForAllOrders { get; set; }

        public string ProductType { get; set; }

    }
}