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
               Title = postProductDto.Title,
               DescriptionRecord = postProductDto.DescriptionRecord,
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
                Title = product.Title,
                DescriptionRecord = product.DescriptionRecord,
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

            product.Title = putProductDto.Title; 
            product.DescriptionRecord = putProductDto.DescriptionRecord;
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
                Title = product.Title,
                DescriptionRecord = product.DescriptionRecord,
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
                Title = deleteProductDto.Title,
                DescriptionRecord= deleteProductDto.DescriptionRecord,
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
               Title= product.Title,
               DescriptionRecord = product.DescriptionRecord,
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
                    Title = item.Title,
                    DescriptionRecord = item.DescriptionRecord,
                    UnitPrice = item.UnitPrice,
                };
                getProductDtos.Add(getProductDto);
            }
            return getProductDtos;
        }
        #endregion
    }
}
