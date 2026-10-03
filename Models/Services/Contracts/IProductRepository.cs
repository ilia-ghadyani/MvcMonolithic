using MvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using MvcMonolithic.Models.DomainModels.PersonAggregates;
using MvcMonolithic.Models.DomainModels.ProductAggregates;

namespace MvcMonolithic.Models.Services.Contracts
{
    public interface IProductRepository
    {
        Task Insert(Product product);
        Task Update(Product product);
        Task<Product?> SelectProductById(GetProductByIdDto getProductByIdDto);
        Task Delete(Product product);
        Task<List<Product>> SelectAll();
    }
}
