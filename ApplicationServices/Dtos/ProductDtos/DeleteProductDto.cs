namespace MvcMonolithic.ApplicationServices.Dtos.ProductDtos
{
    public class DeleteProductDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
    }
}
