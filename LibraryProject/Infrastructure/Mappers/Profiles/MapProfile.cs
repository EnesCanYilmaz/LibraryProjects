namespace LibraryProject.Infrastructure.Mappers.Profiles;

public sealed class MapProfile : Profile
{
    public MapProfile()
    {
        BookMaps();
    }

    private void BookMaps()
    {
        CreateMap<CreateBookRequestModel, Book>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Writer, opt => opt.MapFrom(src => src.Writer))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImageFile))
            .ForMember(dest => dest.IsInLibrary, opt => opt.MapFrom(src => src.IsInLibrary))
            .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate))
            .ReverseMap();
        
        CreateMap<GetAllBooksResponseModel, Book>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Writer, opt => opt.MapFrom(src => src.Writer))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
            .ForMember(dest => dest.IsInLibrary, opt => opt.MapFrom(src => src.IsInLibrary))
            .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate))
            .ReverseMap();
        
        CreateMap<LendBookRequestModel, Book>()
            .ForMember(dest => dest.IsInLibrary, opt => opt.MapFrom(src => src.IsInLibrary))
            .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate))
            .ForMember(dest => dest.Borrower, opt => opt.MapFrom(src => src.Borrower))
            .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();
    }
}