using System.Text.RegularExpressions;
using TheMovies.Core.Interfaces;

namespace TheMovies.Core;

public class Movie : IHasId
{
    //Properties
    public string title { get; set; }
    public MovieGenre MovieGenre { get; set; }    //enum type for genre
    public int duration { get; set; }
    public int Id { get; set; }

    //Constructor
    public Movie(string title, MovieGenre movieGenre, int duration)
    {
        this.title = title;
        this.MovieGenre = movieGenre;
        this.duration = duration;
    }

    public override string ToString()
    {
        return $"{title,-25}{MovieGenre,-25}{duration,-15}Tim Burton 24/12/2008";
    }
}
