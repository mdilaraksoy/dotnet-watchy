namespace watchyproject.Models
{
    public class MoviesModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string PosterUrl { get; set; }
    public string Description { get; set; } 

    public bool IsActive { get; set; } = true;

    }
}
