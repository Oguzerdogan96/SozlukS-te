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

        public void AddEntry(AddEntryDto addEntryDto)
        {
            var entryEntity = new EntryEntity
            {
                UserId = addEntryDto.UserId,
                TitleId = addEntryDto.TitleId,
                Entry = addEntryDto.Entry
            };
            _entryRepository.Add(entryEntity);
        }

        public void AddEntry(int id)
        {
            var viewModel = new EntryEntity
            {
                TitleId = id,
                UserId = 1,
                Entry = "Uyulacak Kurallar",
                
            };

            _entryRepository.Add(viewModel);
        }

        public void DeleteEntry(int id)
        {
            _entryRepository.Delete(id);
        }

        public List<EntryDto> GetEntries()
        {
            var entryEntities =_entryRepository.GetAll();

            var entryDtos = entryEntities.Select(e => new EntryDto
            {
                Id = e.Id,
                TitleId = e.TitleId,
                Entry = e.Entry,
                UserId = e.UserId,
                TitleName = e.Title.Title,
                CreatedDate= e.CreatedDate,
            }).ToList();

            return entryDtos;
                
            
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
                TitleName=x.Title.Title,
                UserId=x.User.Id,
            }).ToList();

            return entryDtos;
        }
    }
}
