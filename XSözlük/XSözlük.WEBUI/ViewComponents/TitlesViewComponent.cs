using Microsoft.AspNetCore.Mvc;
using XSözlük.Business.Services;
using XSözlük.WEBUI.Models;

namespace XSözlük.WEBUI.ViewComponents
{
    public class TitlesViewComponent : ViewComponent
    {
        private readonly ITitleService _titleService;
        private readonly IEntryService _entryService;
        public TitlesViewComponent(ITitleService titleService, IEntryService entryService)
        {
            _titleService = titleService;
            _entryService = entryService;
        }

        public IViewComponentResult Invoke()
        {
            var titleDtos = _titleService.GetTitles();

            var viewModel = titleDtos.Select(x => new TitleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                

            }).ToList();

            for (int i = 0; i < viewModel.Count; i++)
            {
                var x = viewModel[i].Id; //ilgili elemanın idsi

                var y = _entryService.GetEntryByTitleId(x); //ilgili elemanın entryleri

                var z = y.Count(); //ilgili elemanın entry sayısı

                viewModel[i].Count = z;
                
            }

            return View(viewModel);
        }
    }
}
