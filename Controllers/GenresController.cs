namespace MoviesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly IGenericRepository<GenreEntity> _genreRepository;

    public GenresController(IGenericRepository<GenreEntity> genreRepository)
        => _genreRepository = genreRepository;

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<GenreEntity>>> GetGenres()
        => Ok(await _genreRepository.GetAllAsync());

    [HttpGet("{id}", Name = "GetGenre")]
    public async Task<ActionResult<GenreEntity>> GetGenre([FromRoute] Guid id)
    {
        var genreFromDb = await _genreRepository.GetFirstOrDefaultAsync(g => g.Id == id);

        return genreFromDb == null ? NotFound() : Ok(genreFromDb);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGenre([FromBody] GenreEntity genre)
    {
        if (genre == null) return BadRequest();

        await _genreRepository.Add(genre);

        return CreatedAtRoute(nameof(GetGenre), new { genre.Id }, genre);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGenre([FromRoute] Guid id, [FromBody] GenreEntity genre)
    {
        if (id == null) return BadRequest();

        var genreFromDb = await _genreRepository.GetFirstOrDefaultAsync(g => g.Id == id);
        genreFromDb.Id = id;
        genreFromDb.Name = genre.Name;

        await _genreRepository.Update(genreFromDb);

        return CreatedAtRoute(nameof(GetGenre), new { genre.Id }, genre);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGenre([FromRoute] Guid id)
    {
        if (id == null) return BadRequest();

        var genreFromDb = await _genreRepository.GetFirstOrDefaultAsync(g => g.Id == id);

        if (genreFromDb == null) return NotFound();

        await _genreRepository.Delete(genreFromDb);

        return NoContent();
    }
}