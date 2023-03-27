using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSözlük.Business.Dtos;
using XSözlük.Business.Types;

namespace XSözlük.Business.Services
{
    public interface ITitleService
    {
        ServiceMessage AddTitle(AddTitleDto addTitleDto);

        List<TitleDto> GetTitles();

        EditTitleDto GetTitleById(int id);

        void EditTitle(EditTitleDto editTitleDto);

        void DeleteTitle(int id);

    }
}
