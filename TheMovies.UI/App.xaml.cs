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

        // Fixed cinema data
        CinemaRepository.Add(new Cinema { Id = 1, name = "Hjerm"});
        CinemaRepository.Add(new Cinema { Id = 2, name = "Videbæk" });
        CinemaRepository.Add(new Cinema { Id = 3, name = "Thorsminde" });
        CinemaRepository.Add(new Cinema { Id = 4, name = "Ræhr" });

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