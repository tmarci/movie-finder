using MovieFinder.Models;
using MovieFinder.ViewModels;
using MovieFinder.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Services.NavigationService;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace MovieFinder.UserControls
{
    public sealed partial class MovieBrowser : UserControl
    {
        public MovieBrowser()
        {
            this.InitializeComponent();
        }

        public List<IMovieHeader> MovieHeaders
        {
            get { return (List<IMovieHeader>)GetValue(MovieHeadersProperty); }
            set { SetValue(MovieHeadersProperty, value); }
        }

        public static readonly DependencyProperty MovieHeadersProperty =
                 DependencyProperty.Register("MovieHeaders", typeof(List<IMovieHeader>),
                    typeof(MovieBrowser), new PropertyMetadata(new List<IMovieHeader>()));

        //private void MovieHeader_OnItemClick(object sender, ItemClickEventArgs e)
        //{
        //    var movieHeader = (IMovieHeader)e.ClickedItem;
        //    ((MovieBrowserViewModelBase)DataContext).NavigateToDetails(movieHeader.ID);
        //}

        public event ItemClickEventHandler OnItemClick
        {
            add { MoviesGridView.ItemClick += value; }
            remove { MoviesGridView.ItemClick -= value; }
        }
    }
}

