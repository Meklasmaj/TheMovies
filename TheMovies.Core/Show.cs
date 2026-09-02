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
        public DateTime startTime { get; set; }
        public int playTime { get; set; }

    //Constructor
    public Show(Movie movie, Screen screen, DateTime date, DateTime startTime, int playTime)
    {
        Movie = movie;
        Screen = screen;
        Date = date;
        startTime = startTime;
        playTime = playTime;
    }

    public override string ToString()
        {
            return $"{Movie.title,-25}{Screen.screenNumber,-15}{Date.ToShortDateString(),-15}{startTime.ToShortTimeString(),-15}{playTime,-15}";
        }
  
}