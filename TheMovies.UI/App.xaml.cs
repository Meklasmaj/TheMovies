using System.Configuration;
using System.Data;
using System.Windows;
using TheMovies.UI.ViewModels;

namespace TheMovies.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    static MainViewModel _mainViewModel = new MainViewModel();
    public static NavigationService NavigationService = new NavigationService(_mainViewModel);
    
    // Overrides method that runs on startup
    protected override void OnStartup(StartupEventArgs e)
    {
        // Does the normal startup
        base.OnStartup(e);
        
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