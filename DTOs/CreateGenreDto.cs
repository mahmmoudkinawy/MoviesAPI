namespace MoviesAPI.DTOs;
public class CreateGenreDto
{
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }
}