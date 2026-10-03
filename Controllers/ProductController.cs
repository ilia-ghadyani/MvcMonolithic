using Microsoft.AspNetCore.Mvc;
using MvcMonolithic.ApplicationServices;
using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos.PersonDtos;
using MvcMonolithic.ApplicationServices.Dtos.ProductDtos;

namespace MvcMonolithic.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;

        #region [- Ctor() -]
        public ProductController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }
        #endregion

        #region [- Create() -]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostProductDto postProductDto)
        {
            if (ModelState.IsValid)
            {
                await _productApplicationService.Post(postProductDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(postProductDto); // ???
            }
        }
        #endregion

        #region [- Edit() -]
        public async Task<IActionResult> Edit(GetProductByIdDto getProductByIdDto)
        {
            var result = await _productApplicationService.GetProductByID(getProductByIdDto);

            if (result == null)
            {
                return NotFound(); 
            }

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PutProductDto putProductDto)
        {
            if (ModelState.IsValid)
            {
                await _productApplicationService.Put(putProductDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(putProductDto); 
            }
        }
        #endregion

        #region [- Delete() -]
        public async Task<IActionResult> Delete(GetProductByIdDto getProductByIdDto)
        {
            var result = await _productApplicationService.GetProductDelete(getProductByIdDto);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteProductDto deleteProductDto)
        {
            if (ModelState.IsValid)
            {
                await _productApplicationService.Delete(deleteProductDto);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(deleteProductDto); 
            }
        }
        #endregion

        #region [- Details() -]
        public async Task<IActionResult> Details(GetProductByIdDto getProductByIdDto)
        {
            var result = await _productApplicationService.GetProductDetails(getProductByIdDto);

            if (result == null)
            {
                return NotFound(); 
            }

            return View(result);
        }
        #endregion

        #region [- Index() -]
        public async Task<IActionResult> Index()
        {
            var result = await _productApplicationService.GetAllProduct();
            return View(result);
        } 
        #endregion
    }
}
