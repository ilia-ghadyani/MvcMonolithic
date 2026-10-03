namespace MvcMonolithic.Models.DomainModels.ProductAggregates
{
    public class Product
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }
    }
}
