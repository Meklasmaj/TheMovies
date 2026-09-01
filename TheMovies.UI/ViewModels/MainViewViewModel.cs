using System.Windows;
using System.Windows.Input;

namespace TheMovies.UI.ViewModels;

public class MainViewViewModel : ViewModelBase
{
    public RelayCommand RegisterMovieViewCommand { get; private set; }
    public RelayCommand MovieListViewCommand { get; private set; }
    public RelayCommand KillProgramCommand { get; private set; }

    public MainViewViewModel()
    {
        RegisterMovieViewCommand = new RelayCommand(RegisterMovieViewSwitch);
        MovieListViewCommand = new RelayCommand(MovieListViewSwitch);
        KillProgramCommand = new RelayCommand(KillProgram);
    }

    public void RegisterMovieViewSwitch(object parameter)
    {
        // Navigates to RegisterMovieView
        App.NavigationService.NavigateTo<RegisterMovieViewModel>();
    }
    
    public void MovieListViewSwitch(object parameter)
    {
        // Navigates to MovieListView
        App.NavigationService.NavigateTo<MovieListViewModel>();
    }

    /// <summary>
    /// Kills program
    /// </summary>
    /// <param name="parameter"></param>
    public void KillProgram(object parameter)
    {
        Environment.Exit(0);
    }
}