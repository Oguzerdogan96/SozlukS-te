using Microsoft.AspNetCore.Mvc;
using XSözlük.Business.Services;
using XSözlük.WEBUI.Models;

namespace XSözlük.WEBUI.Controllers
{
    
    public class HomeController : Controller
    {

        private readonly IEntryService _entryService;
        public HomeController(IEntryService entryService)
        {
            _entryService = entryService; //Diğer yoldan yaptığım için gerek kalmadı ama belki ilerde lazım olur
        }

        public IActionResult Index(int id)
        {
            var entryDtos = _entryService.GetEntryByTitleId(id);

            //var viewModel = entryDtos.Select(x => new HomeListViewModel
            //{
            //    TitleId = x.TitleId,
            //    Title = x.TitleName,
            //    Entry = x.Entry,
            //    EntryId = x.Id,
            //    CreatedDate = x.CreatedDate,
            //}).ToList();

            //return View(viewModel);

            

            ViewBag.Id = id;
            return View();


        }
    }
}
