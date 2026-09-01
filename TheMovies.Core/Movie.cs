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
    public string movieDirector { get; set; } 
    public DateTime premiereDate { get; set; } = new DateTime();

    //Constructor
    public Movie(string title, MovieGenre movieGenre, int duration, string movieDirector, DateTime premiereDate)
    {
        this.title = title;
        this.MovieGenre = movieGenre;
        this.duration = duration;
        this.movieDirector = movieDirector;
        this.premiereDate = premiereDate;
    }

}
