using MovieFinder.Models;
using MovieFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace MovieFinder.ViewModels
{
    class MovieDetailsViewModel : ViewModelBase
    {
        private Movie _movie;
        public Movie Movie
        {
            get { return _movie; }
            set { Set(ref _movie, value); }
        }

        public override async Task OnNavigatedToAsync(
            object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var movieId = (int)parameter;
            var service = new MovieService();
            Movie = await service.GetMovieAsync(movieId);
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
    }
}
