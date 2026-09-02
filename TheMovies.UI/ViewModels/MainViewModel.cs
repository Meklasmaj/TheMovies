using System.Windows;
using System.Windows.Input;

namespace TheMovies.UI.ViewModels;

public class MainViewModel : ViewModelBase
{
    // Field and Property for an active ViewModel, switching this changes the view.
    private ViewModelBase _currentViewModel;
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(WindowTitle));
        }
    }

    public string WindowTitle
    {
        get
        {
            return CurrentViewModel switch
            {
                MainViewViewModel => "The Movies",
                RegisterMovieViewModel => "The Movies - Registrér film",
                MovieListViewModel => "The Movies - Film",
                MonthlyProgramViewModel => "The Movies - Månedsprogram",
                _ => "The Movies"
            };
        }
    }

    public MainViewModel()
    {
        CurrentViewModel = new MainViewViewModel();
    }
}