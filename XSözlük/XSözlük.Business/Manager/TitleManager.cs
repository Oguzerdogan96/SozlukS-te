using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSözlük.Business.Dtos;
using XSözlük.Business.Services;
using XSözlük.Business.Types;
using XSözlük.Data.Entities;
using XSözlük.Data.Repositories;

namespace XSözlük.Business.Manager
{
    public class TitleManager : ITitleService
    {
        private readonly IRepository<TitleEntity> _titleRepository;
        public TitleManager(IRepository<TitleEntity> titleRepository)
        {
            _titleRepository= titleRepository;
        }

        public ServiceMessage AddTitle(AddTitleDto addTitleDto)
        {
            var hasTitle = _titleRepository.GetAll(x => x.Title.ToLower() == addTitleDto.Title.ToLower()).ToList();

            if (hasTitle.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    ErrorMessage = "Bu isimde bir başlık zaten mevcut."
                };
            }
            var postEntity = new TitleEntity
            {
                Title = addTitleDto.Title,  
            };
            _titleRepository.Add(postEntity);
            return new ServiceMessage
            {
                IsSucceed = true,
            };
        }

        public void DeleteTitle(int id)
        {
           _titleRepository.Delete(id);
        }

        public void EditTitle(EditTitleDto editTitleDto)
        {
            var titleDto= _titleRepository.GetById(editTitleDto.Id);

            titleDto.Title = editTitleDto.Title;

            _titleRepository.Update(titleDto);


        }

        public EditTitleDto GetTitleById(int id)
        {
            var titleDto= _titleRepository.GetById(id);

            return new EditTitleDto
            {
                Title = titleDto.Title,
                Id=titleDto.Id
            };
        }

        public List<TitleDto> GetTitles()
        {
            var titleEntities= _titleRepository.GetAll();

            var titleDtoList = titleEntities.Select(x => new TitleDto
            {
                Id = x.Id,
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                ModifiedDate=x.ModifiedDate,
            }).ToList();

            return titleDtoList;
        }
    }
}
