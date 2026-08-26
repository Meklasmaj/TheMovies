using System.Text.RegularExpressions;

namespace TheMovies.Core;

public class Movie
{
    //Properties
    public string title { get; set; }
    public Genre genre { get; set; }    //enum type for genre
    public int duration { get; set; }

    //Constructor
    public Movie(string title, Genre genre, int duration)
    {
        this.title = title;
        this.genre = genre;
        this.duration = duration;
    }

}
