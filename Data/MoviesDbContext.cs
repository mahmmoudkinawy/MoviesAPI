namespace MoviesAPI.Data;
public class MoviesDbContext : DbContext
{
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
    { }

    public DbSet<GenreEntity> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GenreEntity>().HasData(
            new GenreEntity
            {
                Id = Guid.NewGuid(),
                Name = "Action"
            },
            new GenreEntity
            {
                Id = Guid.NewGuid(),
                Name = "Comedy"
            },
            new GenreEntity
            {
                Id = Guid.NewGuid(),
                Name = "Drama"
            });
    }

}