namespace MoviesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly IGenericRepository<GenreEntity> _genreRepository;
    private readonly IMapper _mapper;

    public GenresController(IGenericRepository<GenreEntity> genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IReadOnlyList<GenreDto>>> GetGenres()
        => Ok(_mapper.Map<IReadOnlyList<GenreDto>>(await _genreRepository.GetAllAsync()));

    [HttpGet("{id}", Name = "GetGenre")]
    public async Task<ActionResult<GenreDto>> GetGenre([FromRoute] Guid id)
    {
        var genreFromDb = await _genreRepository.GetFirstOrDefaultAsync(g => g.Id == id);

        return genreFromDb == null ? NotFound() : Ok(_mapper.Map<GenreDto>(genreFromDb));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDto createGenreDto)
    {
        if (createGenreDto == null) return BadRequest();

        var createdGenre = _mapper.Map<GenreEntity>(createGenreDto);

        await _genreRepository.Add(createdGenre);

        return CreatedAtRoute(nameof(GetGenre), new { createdGenre.Id }, createdGenre);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateGenre([FromRoute] Guid id,
        [FromBody] UpdateGenreDto updateGenreDto)
    {
        updateGenreDto.Id = id;
        if (updateGenreDto == null || id != updateGenreDto.Id) return BadRequest();

        var genreToUpdate = _mapper.Map<GenreEntity>(updateGenreDto);

        await _genreRepository.Update(genreToUpdate);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteGenre([FromRoute] Guid id)
    {
        var genreFromDb = await _genreRepository.GetFirstOrDefaultAsync(g => g.Id == id);

        if (genreFromDb == null) return NotFound();

        await _genreRepository.Delete(genreFromDb);

        return NoContent();
    }
}