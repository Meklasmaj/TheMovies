using System.Collections.ObjectModel;
using TheMovies.Core;

namespace TheMovies.UI.ViewModels;

public class MovieListViewModel : ViewModelBase
{
    public ObservableCollection<Movie> Movies { get; set; }
    public RelayCommand GoBackCommand { get; set; }

    public MovieListViewModel()
    {
        Movies = new ObservableCollection<Movie>(movieRepository.GetAll());
        GoBackCommand = new RelayCommand(GoBack);
    }

    public void GoBack(object parameter)
    {
        // Navigates back to main
        App.NavigationService.NavigateTo<MainViewViewModel>();
    }
}