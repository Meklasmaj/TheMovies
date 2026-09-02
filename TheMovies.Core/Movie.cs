using System.Text.RegularExpressions;
using TheMovies.Core.Interfaces;

namespace TheMovies.Core;

public class Movie : IHasId
{
    //Properties
    public string Title { get; set; }
    public MovieGenre MovieGenre { get; set; }    //enum type for genre
    public int Duration { get; set; }
    public int Id { get; set; }
    public string MovieDirector { get; set; } 
    public DateTime PremiereDate { get; set; } = new DateTime();

    //Constructor
    public Movie(string title, MovieGenre movieGenre, int duration, string movieDirector, DateTime premiereDate)
    {
        this.Title = title;
        this.MovieGenre = movieGenre;
        this.Duration = duration;
        this.MovieDirector = movieDirector;
        this.PremiereDate = premiereDate;
    }

    public override string ToString()
    {
        return $"{Title,-25}{MovieGenre,-25}{Duration,-15}{MovieDirector,-25}{PremiereDate.ToShortDateString(),-15}";
    }
}
