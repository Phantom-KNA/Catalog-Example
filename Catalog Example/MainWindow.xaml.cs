using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Catalog_Example
{


    //Thread _newTaks;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Search();
        }

        private async Task Search()
        {
            string bearerToken = "your-bearer-token-from-TheMovieDb.org";

            // RegisterSettings only needs to be called one time when your application starts-up.
            MovieDbFactory.RegisterSettings(bearerToken);

            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;

            ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync("Star Trek");

            foreach (MovieInfo info in response.Results)
            {
                Console.WriteLine($"{info.Title} ({info.ReleaseDate}): {info.Overview}");
            }
        }
    }
}
