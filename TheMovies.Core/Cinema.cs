using System;
using System.Collections.Generic;
using System.Text;
using TheMovies.Core.Interfaces;

namespace TheMovies.Core; 

    public class Cinema : IHasId
    {
        public int Id { get; set; }
        public string name { get; set; }
        public List<Screen> screens { get; set; } = new List<Screen>();

    //Connstructor
    public Cinema(int id, string name, List<Screen> screens) 
    { 
        Id = id;
        this.name = name;
        this.screens = screens; 
    }

    public void AddScreen(Screen screen)
    {
        screens.Add(screen);
    }

    public void RemoveScreen(Screen screen)
    {
        screens.Remove(screen);
    }


}
