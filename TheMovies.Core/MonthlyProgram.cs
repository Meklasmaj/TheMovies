using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Interfaces;

namespace TheMovies.Core;

public class MonthlyProgram : IHasId
{
    public int Id { get; set; }
    public int Month { get; set; }
    public int Year { get; set; } = 0;
    public Cinema Cinema { get; set; }

    public List<Show> Shows { get; set; } = new List<Show>();

    public MonthlyProgram(int month, int year, Cinema cinema)
    {
        this.Month = month;
        this.Year = year;
        this.Cinema = cinema;
    }

    public void AddShow(Show show)
    {
        Shows.Add(show);
    }

    public void RemoveShow(Show show) 
    { 
        Shows.Remove(show); 
    }

}

