using System.Collections.ObjectModel;
using TheMovies.Core;

namespace TheMovies.UI.ViewModels;

public class MovieListViewModel : ViewModelBase
{
    public ObservableCollection<Movie> Movies { get; set; }
    public ObservableCollection<string> MovieTitles { get; set; }
    public ObservableCollection<string> MovieGenres { get; set; }
    public ObservableCollection<string> MovieDurations { get; set; }
    public RelayCommand GoBackCommand { get; set; }

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

    public MovieListViewModel()
    {
        Movies = new ObservableCollection<Movie>(movieRepository.GetAll());
        MovieTitles = new ObservableCollection<string>();
        MovieGenres = new ObservableCollection<string>();
        MovieDurations = new ObservableCollection<string>();
        foreach (var movie in movieRepository.GetAll())
        {
            MovieTitles.Add(movie.title);
            MovieGenres.Add(movie.MovieGenre.ToString());
            MovieDurations.Add(movie.duration.ToString());
        }
        
        GoBackCommand = new RelayCommand(GoBack);
    }

    public void GoBack(object parameter)
    {
        // Navigates back to main
        App.NavigationService.NavigateTo<MainViewViewModel>();
    }
}