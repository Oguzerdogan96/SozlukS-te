using Microsoft.AspNetCore.Mvc;
using XSözlük.Business.Services;
using XSözlük.WEBUI.Models;

namespace XSözlük.WEBUI.ViewComponents
{
    public class EntriesViewComponent :ViewComponent
    {
        private readonly IEntryService _entryService;
        public EntriesViewComponent(IEntryService entryService)
        {
            _entryService = entryService;
        }

        public IViewComponentResult Invoke(int titleId)
        {
           var entryDtos=  _entryService.GetEntryByTitleId(titleId);

            var viewModel = entryDtos.Select(x => new HomeListViewModel
            {
                TitleId = x.TitleId,
                Title = x.TitleName,
                Entry = x.Entry,
                EntryId = x.Id,
                CreatedDate = x.CreatedDate,
            }).ToList();

            return View(viewModel);
        }
    }
}
