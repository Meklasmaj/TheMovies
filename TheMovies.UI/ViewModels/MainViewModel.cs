using System.Windows.Input;

namespace TheMovies.UI;

public class MainViewModel
{
    public ICommand RegisterMovieViewCommand { get; private set; }
    public ICommand KillProgramCommand { get; private set; }

    public MainViewModel()
    {
        //RegisterMovieViewCommand = new RelayCommand(RegisterMovieViewSwitch);
        //KillProgramCommand = new RelayCommand(KillProgram);
    }

    public void RegisterMovieViewSwitch(object parameter)
    {
        //NAV
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