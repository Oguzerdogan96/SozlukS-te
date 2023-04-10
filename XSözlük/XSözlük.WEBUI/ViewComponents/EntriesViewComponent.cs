using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XSözlük.Business.Services;
using XSözlük.WEBUI.Models;

namespace XSözlük.WEBUI.ViewComponents
{
    public class EntriesViewComponent : ViewComponent
    {
        private readonly IEntryService _entryService;
        private readonly ITitleService _titleService;
        public EntriesViewComponent(IEntryService entryService, ITitleService titleService)
        {
            _entryService = entryService;
            _titleService = titleService;
        }

        public IViewComponentResult Invoke(int titleId)
        {
            if (titleId == 0)
            {
                var entries = _entryService.GetEntries();

                var viewModel2 = entries.Select(x => new HomeListViewModel
                {
                    Title = x.TitleName,
                    TitleId = x.TitleId,
                    Entry = x.Entry,
                    UserId = x.UserId,
                    EntryId = x.Id,
                    CreatedDate = x.CreatedDate,

                }).ToList();



                for (int i = 0; i < entries.Count; i++)
                {
                    viewModel2[i].Sayi = 0;
                }


                return View(viewModel2);
            }
            else
            {
                var entryDtos = _entryService.GetEntryByTitleId(titleId);

                var viewModel = entryDtos.Select(x => new HomeListViewModel
                {
                    TitleId = x.TitleId,
                    Title = x.TitleName,
                    Entry = x.Entry,
                    EntryId = x.Id,
                    CreatedDate = x.CreatedDate,
                    UserId = x.UserId,

                }).ToList();

                return View(viewModel);
            }



        }
    }
}
