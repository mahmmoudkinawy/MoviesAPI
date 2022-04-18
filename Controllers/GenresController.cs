namespace MoviesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly IGenericRepository<GenreEntity> _genreRepository;

    public GenresController(IGenericRepository<GenreEntity> genreRepository)
        => _genreRepository = genreRepository;

    [HttpGet]
    public async Task<IActionResult> GetGenres()
        => Ok(await _genreRepository.GetAllAsync());
}