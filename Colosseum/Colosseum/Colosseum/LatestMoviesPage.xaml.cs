using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colosseum.Models;
using Colosseum.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace Colosseum
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LatestMoviesPage : ContentPage
	{
	    public ObservableCollection<LatestMovie> LatestMovies;
	    private static bool First = true;
        public LatestMoviesPage ()
		{
			InitializeComponent ();
            LatestMovies = new ObservableCollection<LatestMovie>();
		}

	    protected override async void OnAppearing()
	    {
	        base.OnAppearing();
	        if (First)
	        {
	            ApiServices apiServices = new ApiServices();
	            var latestMovies = await apiServices.GetLatestMovies();
	            foreach (var latestMovie in latestMovies)
	            {
	                LatestMovies.Add(latestMovie);
	            }

	            LvLatest.ItemsSource = LatestMovies;
	        }

	        First = false;
        }

	    private void LvLatest_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var items = e.ItemData as LatestMovie;
	        if (items != null)
	        {
	            Navigation.PushAsync(new VideoPage(items.MovieTrailor));
	        }
        }
	}
}