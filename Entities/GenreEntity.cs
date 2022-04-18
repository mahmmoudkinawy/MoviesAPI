namespace MoviesAPI.Entities;
public class GenreEntity
{
    public Guid Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
}