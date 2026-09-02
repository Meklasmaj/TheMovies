using System.Windows;
using TheMovies.Core;
using TheMovies.Core.Interfaces;
using TheMovies.Core.Repositories;
using TheMovies.UI.ViewModels;

namespace TheMovies.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    static MainViewModel _mainViewModel = new MainViewModel();
    public static NavigationService NavigationService = new NavigationService(_mainViewModel);
    
    // Repositories used by MonthlyProgramViewModel
    public static IGenericRepo<Cinema> CinemaRepository = new InMemoryRepository<Cinema>();
    public static IGenericRepo<MonthlyProgram> MonthlyProgramRepository = new FileRepository<MonthlyProgram>("monthlyPrograms.json");

    // Overrides method that runs on startup
    protected override void OnStartup(StartupEventArgs e)
    {
        // Does the normal startup
        base.OnStartup(e);

        // Checks if there are any cinemas in the repository, if not it adds some default cinemas
        if (!CinemaRepository.GetAll().Any())
        {
            CinemaRepository.Add(new Cinema("Hjerm"));
            CinemaRepository.Add(new Cinema("Videbæk"));
            CinemaRepository.Add(new Cinema("Thorsminde"));
            CinemaRepository.Add(new Cinema("Ræhr"));
        }

        // Creates new Window
        var mainWindow = new MainWindow()
        {
            // Setting DataContext of the new Window to viewModelBase
            DataContext = _mainViewModel
        };
        
        // Opens new window
        mainWindow.Show();
    }
}