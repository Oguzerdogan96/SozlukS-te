using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSözlük.Business.Dtos;
using XSözlük.Business.Services;
using XSözlük.Data.Entities;
using XSözlük.Data.Repositories;

namespace XSözlük.Business.Manager
{
    public class EntryManager : IEntryService
    {
        private readonly IRepository<EntryEntity> _entryRepository;
        public EntryManager(IRepository<EntryEntity> entryRepository)
        {
            _entryRepository= entryRepository;
        }
        public List<EntryDto> GetEntryByTitleId(int titleId )
        {
           var entryEntities = _entryRepository.GetAll(x=>x.TitleId==titleId).OrderBy(x=>x.CreatedDate);

            var entryDtos = entryEntities.Select(x=> new EntryDto
            {
                Id= x.Id,
                Entry=x.Entry,
                CreatedDate= x.CreatedDate,
                TitleId=x.Title.Id,
                TitleName=x.Title.Title
            }).ToList();

            return entryDtos;
        }
    }
}
