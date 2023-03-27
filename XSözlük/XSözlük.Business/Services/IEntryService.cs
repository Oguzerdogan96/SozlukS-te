using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSözlük.Business.Dtos;

namespace XSözlük.Business.Services
{
    public interface IEntryService
    {
       List<EntryDto> GetEntryByTitleId(int titleId ) ;
    }
}
