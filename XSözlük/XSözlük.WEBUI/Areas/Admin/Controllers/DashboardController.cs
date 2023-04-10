using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using XSözlük.Business.Dtos;
using XSözlük.Business.Services;
using XSözlük.WEBUI.Areas.Admin.Models;

namespace XSözlük.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly ITitleService _titleService;
        private readonly IEntryService _entryService;
        public DashboardController(ITitleService titleService, IEntryService entryService)
        {
            _titleService = titleService;
            _entryService = entryService;
        }
        public IActionResult List()
        {
            var titleList = _titleService.GetTitles();
            var viewModel = titleList.Select(x => new ListTitleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,

            }).ToList();

            return View("ListTitle", viewModel);
        }
        [HttpGet]
        public IActionResult AddTitle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTitle(AddTitleViewModel formData)
        {
            var addTitleDto = new AddTitleDto
            {
                Id = formData.Id,
                Title = formData.Title,
            };

            var response = _titleService.AddTitle(addTitleDto);

            if (!response.IsSucceed)
            {
                ViewBag.ErrorMessage = response.ErrorMessage;
                return View(formData);
            }

            var viewModel = _titleService.GetTitles();

            var x = viewModel[viewModel.Count - 1].Id;  //en son eklenen başlığın idsini çektim

            _entryService.AddEntry(x);
            

            return RedirectToAction("List");

        }
        [HttpGet]
        public IActionResult EditTitle(int id)
        {
            var titleDto = _titleService.GetTitleById(id);

            var viewModel = new TitleViewModel
            {
                Title = titleDto.Title,
                Id = titleDto.Id
            };
            return View(viewModel);

        }
        [HttpPost]
        public IActionResult EditTitle(TitleViewModel formData)
        {
            var editTitleDto = new EditTitleDto
            {
                Id = formData.Id,
                Title = formData.Title,
            };
            _titleService.EditTitle(editTitleDto);

            return RedirectToAction("List");

        }
        public IActionResult DeleteTitle(int id)
        {
            _titleService.DeleteTitle(id);

            return RedirectToAction("List");
        }
    }
}
