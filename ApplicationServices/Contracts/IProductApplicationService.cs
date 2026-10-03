using MvcMonolithic.ApplicationServices.Dtos.ProductDtos;

namespace MvcMonolithic.ApplicationServices.Contracts
{
    public interface IProductApplicationService
    {
        Task Post(PostProductDto postProductDto);
        Task<PutProductDto?> GetProductByID(GetProductByIdDto getProductByIdDto);
        Task Put(PutProductDto putProductDto);
        Task Delete(DeleteProductDto deleteProductDto);
        Task<DeleteProductDto?> GetProductDelete(GetProductByIdDto getProductByIdDto);
        Task<DetailsProductDto?> GetProductDetails(GetProductByIdDto getProductByIdDto);
        Task<List<GetProductDto>> GetAllProduct();
    }
}
