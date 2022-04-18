namespace MoviesAPI.DTOs;
public class UpdateGenreDto
{
    [Required]
    public Guid Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; }
}