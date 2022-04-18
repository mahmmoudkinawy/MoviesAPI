namespace MoviesAPI.Helpers;
public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<GenreEntity, GenreDto>();
        CreateMap<CreateGenreDto, GenreEntity>();
        CreateMap<UpdateGenreDto, GenreEntity>();
    }
}