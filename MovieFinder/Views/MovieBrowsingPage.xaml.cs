using MovieFinder.Models;
using System;
using Windows.UI.Xaml.Controls;

namespace MovieFinder.Views
{
    public sealed partial class MovieBrowsingPage : Page
    {
        public MovieBrowsingPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            MovieBrowser.OnItemClick += MovieBrowser_OnItemClick;
        }

        private void MovieBrowser_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var movieHeader = (IMovieHeader)e.ClickedItem;
            ViewModel.NavigateToDetails(movieHeader.ID);
        }
    }
}