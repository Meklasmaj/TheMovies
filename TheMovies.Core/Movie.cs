using System.Text.RegularExpressions;

namespace TheMovies.Core;

public class Movie
{
    //Properties
    public string Title { get; set; }
    public genre Genre { get; set; }    //enum type for genre
    public int Duration { get; set; }

    //Constructor
    public Movie(string title, genre genre, int duration)
    {
        Title = title;
        Genre = genre;
        Duration = duration;
    }

}
