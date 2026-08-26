using System.Text.RegularExpressions;
using TheMovies.Core.Interfaces;

namespace TheMovies.Core;

public class Movie : IHasId
{
    //Properties
    public string title { get; set; }
    public Genre genre { get; set; }    //enum type for genre
    public int duration { get; set; }
    public int Id { get; set; }

    //Constructor
    public Movie(string title, Genre genre, int duration)
    {
        this.title = title;
        this.genre = genre;
        this.duration = duration;
    }

}
