using Application.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                #region Notes
                cfg.CreateMap<Note, NoteDto>();
                cfg.CreateMap<CreateNoteDto, Note>();
                cfg.CreateMap<UpdateNoteDto, Note>();
                #endregion

                #region Categories
                cfg.CreateMap<Category, CategoryDto>(); 
                cfg.CreateMap<CreateCategoryDto, Category>();
                cfg.CreateMap<UpdateCategoryDto, Category>();
                #endregion
            }).CreateMapper();  
    }
}
  