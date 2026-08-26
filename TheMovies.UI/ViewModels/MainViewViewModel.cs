using System.Windows;
using System.Windows.Input;

namespace TheMovies.UI.ViewModels;

public class MainViewViewModel : ViewModelBase
{
    public ICommand RegisterMovieViewCommand { get; private set; }
    public ICommand KillProgramCommand { get; private set; }

    public MainViewViewModel()
    {
        RegisterMovieViewCommand = new RelayCommand(RegisterMovieViewSwitch);
        KillProgramCommand = new RelayCommand(KillProgram);
    }

    public void RegisterMovieViewSwitch(object parameter)
    {
        //App.NavigationService.NavigateTo<RegisterMovieViewModel>();
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