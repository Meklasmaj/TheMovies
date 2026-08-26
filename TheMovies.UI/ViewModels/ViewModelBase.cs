using System.ComponentModel;
using System.Runtime.CompilerServices;
using TheMovies.Core;
using TheMovies.Core.Interfaces;
using TheMovies.UI;

namespace TheMovies.UI.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected readonly IGenericRepo<Movie> movieRepository;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}