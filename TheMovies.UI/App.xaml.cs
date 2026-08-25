using System.Configuration;
using System.Data;
using System.Windows;
using TheMovies.Ui.ViewModels;

namespace TheMovies.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    static ViewModelBase viewModelBase = new ViewModelBase();
    public static NavigationService NavigationService = new NavigationService(viewModelBase);
    
    // Overrides method that runs on startup
    protected override void OnStartup(StartupEventArgs e)
    {
        // Does the normal startup
        base.OnStartup(e);
        
        // Creates new Window
        var mainWindow = new MainWindow()
        {
            // Setting DataContext of the new Window to viewModelBase
            DataContext = viewModelBase
        };
        
        // Opens new window
        mainWindow.Show();
    }
}