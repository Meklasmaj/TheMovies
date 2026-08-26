using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using TheMovies.Core;
using TheMovies.Core.Interfaces;

namespace TheMovies.UI.ViewModels
{
    // This class is responsible for handling the logic of the RegisterMovieView
    internal class RegisterMovieViewModel : ViewModelBase
    {

        public string Title { get; set; }

        public Genre Genre { get; set; }
        public Genre[] Genres { get; } => Enum.GetValues<Genre>();

        public int Duration { get; set; }


        public ICommand RegisterMovieCommand { get; }
        public ICommand GoBackCommand { get; }


        public RegisterMovieViewModel()
        {
            //  Initialize commands with RelayCommand
            RegisterMovieCommand = new RelayCommand(RegisterMovie);
            GoBackCommand = new RelayCommand(GoBack);

        }

        public void RegisterMovie(object parameter)
        {
            // register a new movie
            Movie movie = new Movie
            {
                Title = this.Title,
                Genre = this.Genre,
                Duration = this.Duration,
            };

            movieRepository.Add(movie); // Assuming _movieRepository is defined and initialized elsewhere

        }

        public void GoBack(object parameter)
        {
            // navigate back to the previous view

        }
    }
}
