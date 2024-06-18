using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using MovieFinder.Services;
using MovieFinder.Models;
using Windows.UI.Xaml.Data;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Core;
using static MovieFinder.ViewModels.MovieBrowserViewModelBase;
using MovieFinder.Views;

namespace MovieFinder.ViewModels
{
    public class MovieBrowserViewModel : MovieBrowserViewModelBase
    {
        public MovieBrowserViewModel()
        {
            this.MovieHeaders = new IncrementalMoviesPageLoadingCollection();
        }

        public override async Task OnNavigatedToAsync(
                object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            //this.MovieHeaders = new IncrementalMoviesPageLoadingCollection();
        }

        public void NavigateToDetails(int id)
        {
            NavigationService.Navigate(typeof(MovieDetailsPage), id);
        }
    }

    public class IncrementalMoviesPageLoadingCollection : IncrementalPageLoadingCollection
    {
        protected override async Task<MoviesPage> LoadNextPage(int pageNumber)
        {
            MovieService service = new MovieService();
            return await service.GetPopularMoviesPageAsync(pageNumber);
        }
    }
}
