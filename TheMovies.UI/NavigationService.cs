using TheMovies.UI.ViewModels;

namespace TheMovies.UI;

public class NavigationService
{
    private readonly MainViewModel _mainViewModel;

    public NavigationService(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    // Method that switches active view model to a generic(T) view model. Next viewmodel needs to be new
    public void NavigateTo<T>() where T : ViewModelBase, new()
    {
        _mainViewModel.CurrentViewModel = new T();
    }
}