namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                #region Notes
                cfg.CreateMap<Note, NoteDto>()
                    .ForMember(dest =>dest.Updated, act => act.MapFrom(src => src.Details.Updated));
                cfg.CreateMap<IEnumerable<Note>, ListNotesDto>()
                    .ForMember(dest => dest.Notes, act => act.MapFrom(src => src))
                    .ForMember(dest => dest.Count, act => act.MapFrom(src => src.Count()));
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
  