using Microsoft.AspNetCore.Mvc;
using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos.PersonDtos;

namespace MvcMonolithic.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonApplicationService _personApplicationService;

        #region [- Ctor() -]
        public PersonController(IPersonApplicationService personApplicationService)
        {
            _personApplicationService = personApplicationService;
        }
        #endregion

        #region [- Create() -]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostPersonDto postPersonDto)
        {
            if (ModelState.IsValid)
            {
                await _personApplicationService.Post(postPersonDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(postPersonDto); 
            }
        }
        #endregion

        #region [- Edit() -]
        public async Task<IActionResult> Edit(GetPersonByIdDto getPersonByIdDto)
        {
            var result = await _personApplicationService.GetPersonById(getPersonByIdDto);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PutPersonDto putPersonDto)
        {
            if (ModelState.IsValid)
            {
                await _personApplicationService.Put(putPersonDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(putPersonDto);
            }
        }
        #endregion

        #region [- Delete() -]
        public async Task<IActionResult> Delete(GetPersonByIdDto getPersonByIdDto)
        {
            var result = await _personApplicationService.GetPersonDelete(getPersonByIdDto);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeletePersonDto deletePersonDto)
        {
            if (ModelState.IsValid)
            {
                await _personApplicationService.Delete(deletePersonDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(deletePersonDto);
            }
        }
        #endregion

        #region [- Details() -]
        public async Task<IActionResult> Details(GetPersonByIdDto getPersonByIdDto)
        {
            var result = await _personApplicationService.GetPersonDetails(getPersonByIdDto);

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
            var result = await _personApplicationService.GetAllPerson();
            return View(result);
        }
        #endregion
    }
}
