using System.Collections.ObjectModel;
using TheMovies.Core;

namespace TheMovies.UI.ViewModels;

public class MovieListViewModel : ViewModelBase
{
    public ObservableCollection<Movie> Movies { get; set; }
    public RelayCommand GoBackCommand { get; set; }
    public RelayCommand DeleteMovieCommand { get; set; }

    private string _columns = $"{"Titel",-25}{"Genre",-25}{"Varighed",-15}";
    public string Columns
    {
        get => _columns;
        set
        {
            _columns = value;
            OnPropertyChanged();
        }
    }
    
    private Movie _selectedMovie;

    public Movie SelectedMovie
    {
        get => _selectedMovie;
        set
        {
            _selectedMovie = value;
            OnPropertyChanged();
            DeleteMovieCommand.RaiseCanExecuteChanged();
        }
    }

    public MovieListViewModel()
    {
        Movies = new ObservableCollection<Movie>(movieRepository.GetAll());
        
        GoBackCommand = new RelayCommand(GoBack);
        DeleteMovieCommand = new RelayCommand(DeleteMovie, CanDeleteMovie);
    }

    public void DeleteMovie(object parameter)
    {
        movieRepository.Remove(SelectedMovie.Id);
        Movies.Remove(SelectedMovie);
    }

    public bool CanDeleteMovie(object parameter)
    {
        return  SelectedMovie != null;
    }

    public void GoBack(object parameter)
    {
        // Navigates back to main
        App.NavigationService.NavigateTo<MainViewViewModel>();
    }
}