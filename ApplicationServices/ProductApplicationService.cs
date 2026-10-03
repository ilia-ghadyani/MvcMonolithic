using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using MvcMonolithic.Models.DomainModels.ProductAggregates;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.ApplicationServices
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductRepository _productRepository;

        #region [- Ctor() -]
        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region [- Post() -]
        public async Task Post(PostProductDto postProductDto)
        {
            var product = new Product
            {
               ProductName = postProductDto.ProductName,
               ProductDescription = postProductDto.ProductDescription,
               UnitPrice = postProductDto.UnitPrice,
            };
            await _productRepository.Insert(product);
        }
        #endregion

        #region [- GetProductByID() -]
        public async Task<PutProductDto?> GetProductByID(GetProductByIdDto getProductByIdDto)
        {
            var product = await _productRepository.SelectProductById(getProductByIdDto);

            if (product == null)
            {
                return null;
            }
            var putProductDto = new PutProductDto
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                UnitPrice = product.UnitPrice,
            };
            return putProductDto;

        }
        #endregion

        #region [- Put() -]
        public async Task Put(PutProductDto putProductDto)
        {
            var getProductByIdDto = new GetProductByIdDto
            {
                Id = putProductDto.Id,
            };
            var product = await _productRepository.SelectProductById(getProductByIdDto);

            if (product == null) 
            {
                return;
            }

            product.ProductName = putProductDto.ProductName; 
            product.ProductDescription = putProductDto.ProductDescription;
            product.UnitPrice = putProductDto.UnitPrice;

            await _productRepository.Update(product);
        }
        #endregion

        #region [- GetProductDelete() -]
        public async Task<DeleteProductDto?> GetProductDelete(GetProductByIdDto getProductByIdDto)
        {
            var product = await _productRepository.SelectProductById(getProductByIdDto);

            if (product == null)
            {
                return null;
            }

            var deleteProductDto = new DeleteProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                UnitPrice = product.UnitPrice,
            };

            return deleteProductDto;
        }
        #endregion

        #region [- Delete() -]
        public async Task Delete(DeleteProductDto deleteProductDto)
        {
            var product = new Product
            {
                Id = deleteProductDto.Id,
                ProductName = deleteProductDto.ProductName,
                ProductDescription= deleteProductDto.ProductDescription,
                UnitPrice= deleteProductDto.UnitPrice,
            };

            await _productRepository.Delete(product);
        }
        #endregion

        #region [- GetProductDetails() -]
        public async Task<DetailsProductDto?> GetProductDetails(GetProductByIdDto getProductByIdDto)
        {
            var product = await _productRepository.SelectProductById(getProductByIdDto);

            if (product == null)
            {
                return null;
            }
            var detailProductDto = new DetailsProductDto
            {
               Id= product.Id,
               ProductName= product.ProductName,
               ProductDescription = product.ProductDescription,
               UnitPrice = product.UnitPrice
            };
            return detailProductDto;
        }
        #endregion

        #region [- GetAllProduct() -]
        public async Task<List<GetProductDto>> GetAllProduct()
        {
            var products = await _productRepository.SelectAll();
            var getProductDtos = new List<GetProductDto>();
            foreach (var item in products)
            {
                var getProductDto = new GetProductDto()
                {
                    Id = item.Id,
                    ProductName = item.ProductName,
                    ProductDescription = item.ProductDescription,
                    UnitPrice = item.UnitPrice,
                };
                getProductDtos.Add(getProductDto);
            }
            return getProductDtos;
        }
        #endregion
    }
}
