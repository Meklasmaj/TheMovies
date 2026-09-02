using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Interfaces;

namespace TheMovies.Core; 

    public class Cinema : IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Screen> Screens { get; set; } = new List<Screen>();

    public Cinema() { }

    // Original constructor
    public Cinema(int id, string name, List<Screen> screens) 
    { 
        Id = id;
        this.Name = name;
        this.Screens = screens; 
    }

    // Bonus constructor for fixed cinema data
    public Cinema(string name)
    {
        this.Name = name;
        this.Screens = new List<Screen>();
    }

    public void AddScreen(Screen screen)
    {
        this.Screens.Add(screen);
    }

    public void RemoveScreen(Screen screen)
    {
        this.Screens.Remove(screen);
    }


}
