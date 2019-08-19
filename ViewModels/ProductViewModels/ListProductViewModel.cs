namespace api_netcore_and_ef.ViewModels.ProductViewModels
{
    public class ListProductViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int IdCategory { get; set; }
         
        public string Category { get; set; }
    }
}