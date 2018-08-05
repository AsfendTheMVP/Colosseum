using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colosseum.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colosseum
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowPlayingDetailPage : ContentPage
    {
        private string _trailorLink;
        private string _time1;
        private string _time2;
        private string _time3;
        private string _ticketPrice;


        public NowPlayingDetailPage(NowPlayingMovie nowPlayingMovie)
        {
            InitializeComponent();
            LblMovieName.Text = nowPlayingMovie.MovieName;
            ImgMovieCover.Source = nowPlayingMovie.CoverImage;
            LblDuration.Text = nowPlayingMovie.Duration;
            LblLanguage.Text = nowPlayingMovie.Language;
            LblMovieType.Text = nowPlayingMovie.Genre;
            LblPlayingDate.Text = nowPlayingMovie.PlayingDate.ToShortDateString();
            LblCast.Text = nowPlayingMovie.Cast;
            LblDescription.Text = nowPlayingMovie.Description;
            LblRatedLevel.Text = nowPlayingMovie.RatedLevel;
            _trailorLink = nowPlayingMovie.MovieTrailor;
            _time1 = nowPlayingMovie.ShowTime1.ToShortTimeString();
            _time2 = nowPlayingMovie.ShowTime2.ToShortTimeString();
            _time3 = nowPlayingMovie.ShowTime3.ToShortTimeString();
            _ticketPrice = nowPlayingMovie.TicketPrice;
        }

        private void PlayVideo_OnTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VideoPage(_trailorLink));
        }

        private void BtnBookTicket_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BookTicketPage(ImgMovieCover.Source,LblMovieName.Text,LblPlayingDate.Text,_time1,_time2,_time3,_ticketPrice));
        }
    }
}