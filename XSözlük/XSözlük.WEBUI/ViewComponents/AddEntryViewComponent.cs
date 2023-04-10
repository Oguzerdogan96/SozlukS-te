using Microsoft.AspNetCore.Mvc;
using XSözlük.Business.Services;
using XSözlük.WEBUI.Models;

namespace XSözlük.WEBUI.ViewComponents
{
    public class AddEntryViewComponent :ViewComponent
    {
        private readonly IEntryService _entryService;
        public AddEntryViewComponent(IEntryService entryService)
        {
            _entryService = entryService;
        }
        public IViewComponentResult Invoke(int titleId,int userId)
        {
            var viewModel = new EntryAddViewModel
            {
                TitleId = titleId,
                UserId = userId,
                Entry = null

            };
            return View(viewModel);
        }
    }
}
