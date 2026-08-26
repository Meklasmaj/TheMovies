using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheMovies.Core;

namespace TheMovies.UI
{
    /// <summary>
    /// Interaction logic for RegisterMovieView.xaml
    /// </summary>
    public partial class RegisterMovieView : UserControl
    {
        public RegisterMovieView()
        {
            InitializeComponent();
            //Below do we need to add this to be able to safe the movie to the file?
            //IGenericRepo repo = new FileGenericRepository<Movie>("movies.json");
        }
    }
}
