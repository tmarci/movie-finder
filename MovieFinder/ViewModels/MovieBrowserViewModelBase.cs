using MovieFinder.Models;
using MovieFinder.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MovieFinder.ViewModels
{
    public abstract class MovieBrowserViewModelBase :ViewModelBase
    {
        public IncrementalPageLoadingCollection MovieHeaders { get; set; }
    }

    public abstract class IncrementalPageLoadingCollection : ObservableCollection<IMovieHeader>, ISupportIncrementalLoading
    {
        private int pagesLoaded = 0;
        public bool HasMoreItems { get { return pagesLoaded < 100; } }
        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            var dispatcher = Window.Current.Dispatcher;

            return Task.Run(async () =>
            {
                var moviesPage = await LoadNextPage(pagesLoaded + 1);
                if (moviesPage.total_pages <= pagesLoaded)
                    return new LoadMoreItemsResult { Count = 0 };

                uint itemsLoaded = 0;
                pagesLoaded++;
                await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    foreach (var item in moviesPage.results)
                    {
                        Add(item);
                        itemsLoaded++;
                    }
                });

                return new LoadMoreItemsResult { Count = itemsLoaded };

            }).AsAsyncOperation();
        }

        protected abstract Task<MoviesPage> LoadNextPage(int pageNumber);
    }
}
