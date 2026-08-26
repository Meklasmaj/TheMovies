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
    public class RegisterMovieViewModel : ViewModelBase
    {
        private readonly IGenericRepo<Movie> movieRepository;
       
        public string title 
        {
            get => title; 
            set
            { title = value; OnPropertyChanged();  
            }
        }

        public Genre genre
        {
            get => genre;
            set
            {
                genre = value; OnPropertyChanged();
            }
        }

        public Genre[] genres { get; } => Enum.GetValues<Genre>();

        public int duration  
        { 
            get => duration;
            set
            {
                duration = value; OnPropertyChanged();
            }
        }

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
            Movie movie = new Movie(title, genre, duration);
        
            movieRepository.Add(movie); // Assuming _movieRepository is defined and initialized elsewhere

        }

        public void GoBack(object parameter)
        {
            // navigate back to the previous view

        }
    }
}
