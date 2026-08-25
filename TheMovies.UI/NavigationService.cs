namespace TheMovies.UI;

public class NavigationService
{
    private readonly MainViewModel _mainViewModel;

    public NavigationService(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    /*public void NavigateTo<T>() where T : ViewModelBase, new()
    {
        _mainViewModel.CurrentViewModel = new T();
    }*/
}