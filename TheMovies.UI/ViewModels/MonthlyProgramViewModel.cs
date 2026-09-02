using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using TheMovies.Core;
using TheMovies.Core.Interfaces;
using TheMovies.UI.ViewModels;

namespace TheMovies.UI.ViewModels
{
    public class MonthlyProgramViewModel : ViewModelBase
    {
        private int _month;
        private int _year;

        private Cinema? _cinema;
        private DateTime _date;
        private Screen? _screen;
        private Movie? _movie;
        private DateTime _startTime;
        private Show? _selectedShow;

        private readonly IGenericRepo<Cinema> cinemaRepository;
        private readonly IGenericRepo<MonthlyProgram> monthlyProgramRepository;

        // Choices for ComboBoxes
        public ObservableCollection<Cinema> Cinemas { get; }
        public ObservableCollection<Screen> Screens { get; }
        public ObservableCollection<Movie> Movies { get; }

        // Shows in the current monthly program
        public ObservableCollection<Show> Shows { get; }

        public int Month
        {
            get => _month;
            set
            {
                _month = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MonthDisplay));
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MonthDisplay));
            }
        }

        public Cinema? Cinema
        {
            get => _cinema;
            set
            {
                _cinema = value;
                OnPropertyChanged();

                LoadScreens();
                LoadMonthlyProgram();

                SaveShowCommand.RaiseCanExecuteChanged();
                SaveMonthlyProgramCommand.RaiseCanExecuteChanged();
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();

                SaveShowCommand.RaiseCanExecuteChanged();
            }
        }

        public Screen? Screen
        {
            get => _screen;
            set
            {
                _screen = value;
                OnPropertyChanged();

                SaveShowCommand.RaiseCanExecuteChanged();
            }
        }

        public Movie? Movie
        {
            get => _movie;
            set
            {
                _movie = value;
                OnPropertyChanged();

                SaveShowCommand.RaiseCanExecuteChanged();
            }
        }

        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                OnPropertyChanged();

                SaveShowCommand.RaiseCanExecuteChanged();
            }
        }

        public Show? SelectedShow
        {
            get => _selectedShow;
            set
            {
                _selectedShow = value;
                OnPropertyChanged();

                DeleteShowCommand.RaiseCanExecuteChanged();
            }
        }

        public string MonthDisplay
        {
            get
            {
                if (Month < 1 || Month > 12 || Year < 1)
                {
                    return "";
                }

                DateTime date = new DateTime(Year, Month, 1);

                string result = date.ToString("MMMM yyyy", new CultureInfo("da-DK"));

                return char.ToUpper(result[0]) + result[1..];
            }
        }

        public RelayCommand SaveShowCommand { get; }
        public RelayCommand SaveMonthlyProgramCommand { get; }
        public RelayCommand DeleteShowCommand { get; }
        public RelayCommand GoBackCommand { get; }


        public MonthlyProgramViewModel()
        {
            cinemaRepository = App.CinemaRepository;
            monthlyProgramRepository = App.MonthlyProgramRepository;

            DateTime nextMonth = DateTime.Today.AddMonths(1);

            _month = nextMonth.Month;
            _year = nextMonth.Year;

            _date = new DateTime(nextMonth.Year, nextMonth.Month, 1);

            _startTime = _date;

            Cinemas = new ObservableCollection<Cinema>();
            Screens = new ObservableCollection<Screen>();
            Movies = new ObservableCollection<Movie>(movieRepository.GetAll());
            Shows = new ObservableCollection<Show>();

            SaveShowCommand = new RelayCommand(SaveShow, CanSaveShow);
            SaveMonthlyProgramCommand = new RelayCommand(SaveMonthlyProgram, CanSaveMonthlyProgram);
            DeleteShowCommand = new RelayCommand(DeleteShow, CanDeleteShow);
            GoBackCommand = new RelayCommand(GoBack);

            LoadCinemas();
        }


        private void LoadCinemas()
        {
            Cinemas.Clear();

            foreach (Cinema cinema in cinemaRepository.GetAll())
            {
                Cinemas.Add(cinema);
            }
        }

        private void LoadScreens()
        {
            Screens.Clear();

            if (Cinema == null)
                return;

            foreach (Screen screen in Cinema.Screens)
            {
                Screens.Add(screen);
            }

            Screen = null;
        }

        private void LoadMonthlyProgram()
        {
            Shows.Clear();

            if (Cinema == null)
                return;

            MonthlyProgram? existingProgram = monthlyProgramRepository.GetAll()
                .FirstOrDefault(program => program.Month == Month && program.Year == Year && program.Cinema.Name == Cinema.Name);

            if (existingProgram == null)
                return;

            foreach (Show show in existingProgram.Shows)
            {
                Shows.Add(show);
            }

            SaveMonthlyProgramCommand.RaiseCanExecuteChanged();
        }

        private bool CanSaveShow(object? parameter)
        {
            return Cinema != null
                && Screen != null
                && Movie != null
                && Date.Month == Month
                && Date.Year == Year;
        }

        private void SaveShow(object? parameter)
        {
            DateTime startTime = Date.Date + StartTime.TimeOfDay;

            int PlayTime = Movie!.Duration + 15 + 15; // duration + 15 min ads + 15 min cleaning

            Show show = new Show(Movie!, Screen!, Date.Date, startTime, PlayTime);

            Shows.Add(show);

            SaveMonthlyProgramCommand.RaiseCanExecuteChanged();
        }

        private bool CanSaveMonthlyProgram(object? parameter)
        {
            return Cinema != null && Shows.Count > 0;
        }

        private void SaveMonthlyProgram(object? parameter)
        {
            if (Cinema == null)
                return;

            MonthlyProgram monthlyProgram = new MonthlyProgram(Month, Year, Cinema);

            foreach (Show show in Shows)
            {
                monthlyProgram.AddShow(show);
            }

            monthlyProgramRepository.Add(monthlyProgram);
        }

        private bool CanDeleteShow(object? parameter)
        {
            return SelectedShow != null;
        }

        private void DeleteShow(object? parameter)
        {
            if (SelectedShow != null)
                return;

            Shows.Remove(SelectedShow);

            SelectedShow = null;

            SaveMonthlyProgramCommand.RaiseCanExecuteChanged();
        }

        private void GoBack(object? parameter)
        {
            App.NavigationService.NavigateTo<MainViewViewModel>();
        }
    }
}