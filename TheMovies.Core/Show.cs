using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Interfaces;

namespace TheMovies.Core;

public class Show : IHasId
{
    public int Id { get; set; }
    public Movie Movie { get; set; }
    public Screen Screen { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public int PlayTime { get; set; }

    public DateTime EndTime
    {
        get => StartTime.AddMinutes(PlayTime + 30); // Adding 30 minutes for cleaning time and ads
    }

    //Constructor
    public Show(Movie movie, Screen screen, DateTime date, DateTime startTime, int playTime)
    {
        Movie = movie;
        Screen = screen;
        Date = date;
        StartTime = startTime;
        PlayTime = playTime;
    }

    public override string ToString()
    {
        return $"{Movie.Title,-25}{Screen.ScreenNumber,-15}{Date.ToShortDateString(),-15}{StartTime.ToShortTimeString(),-15}{PlayTime,-15}";
    }
}
