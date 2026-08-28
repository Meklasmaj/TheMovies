using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TheMovies.Core;
using TheMovies.Core.Interfaces;

namespace TheMovies.UI.ViewModels
{
    // This class is responsible for handling the logic of the RegisterMovieView
    public class RegisterMovieViewModel : ViewModelBase
    {
        private string _title;
        public string title 
        {
            get => _title; 
            set
            { _title = value; OnPropertyChanged();
                RegisterMovieCommand.RaiseCanExecuteChanged();
            }
        }

        private MovieGenre _movieGenre;
        public MovieGenre MovieGenre
        {
            get => _movieGenre;
            set
            {
                _movieGenre = value; OnPropertyChanged();
            }
        }

        public MovieGenre[] Genres => Enum.GetValues<MovieGenre>();

        private int _duration;
        public int duration  
        { 
            get => _duration;
            set
            {
                _duration = value; OnPropertyChanged();
                RegisterMovieCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand RegisterMovieCommand { get; }
        public RelayCommand GoBackCommand { get; }


        public RegisterMovieViewModel()
        {
            //  Initialize commands with RelayCommand
            RegisterMovieCommand = new RelayCommand(RegisterMovie, CanRegisterMovie);
            GoBackCommand = new RelayCommand(GoBack);

        }

        public void RegisterMovie(object parameter)
        {
            // register a new movie
            Movie movie = new Movie(title, MovieGenre, duration);
        
            movieRepository.Add(movie); // Assuming _movieRepository is defined and initialized elsewhere
            
            MessageBox.Show($"{title}, {MovieGenre}, {duration}");
            title = "";
            MovieGenre = MovieGenre.ActionandAdventure;
            duration = 0;

        }
        
        public bool CanRegisterMovie(object parameter)
        {
            return !string.IsNullOrWhiteSpace(title) && duration > 0;
        }

        public void GoBack(object parameter)
        {
            // navigate back to the previous view
            App.NavigationService.NavigateTo<MainViewViewModel>();
        }
    }
}
