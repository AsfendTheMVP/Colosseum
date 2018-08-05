using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colosseum.Models;
using Colosseum.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colosseum
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookTicketPage : ContentPage
    {
        private string bookingTime;
        public BookTicketPage(ImageSource imageSource, string movieName, string playingDate, string t1, string t2, string t3, string ticketPrice)
        {
            InitializeComponent();
            ImgMovieCover.Source = imageSource;
            LblMovieName.Text = movieName;
            LblPlayingDate.Text = playingDate;
            LblTime1.Text = t1;
            LblTime2.Text = t2;
            LblTime3.Text = t3;
            SpanAmount.Text = SpanTotalPrice.Text = ticketPrice;
            SpanQty.Text = "1";
        }

        private void Tap1_OnTapped(object sender, EventArgs e)
        {
            Frame1.BackgroundColor = Color.LightGray;
            Frame2.BackgroundColor = Color.FromHex("#FF5722");
            Frame3.BackgroundColor = Color.FromHex("#FF5722");
            bookingTime = LblTime1.Text;
        }

        private void Tap2_OnTapped(object sender, EventArgs e)
        {
            Frame1.BackgroundColor = Color.FromHex("#FF5722");
            Frame2.BackgroundColor = Color.LightGray;
            Frame3.BackgroundColor = Color.FromHex("#FF5722");
            bookingTime = LblTime2.Text;
        }

        private void Tap3_OnTapped(object sender, EventArgs e)
        {
            Frame1.BackgroundColor = Color.FromHex("#FF5722");
            Frame2.BackgroundColor = Color.FromHex("#FF5722");
            Frame3.BackgroundColor = Color.LightGray;
            bookingTime = LblTime3.Text;
        }

        private async void BtnBookTicket_OnClicked(object sender, EventArgs e)
        {
            var bookTicket = new BookTicket()
            {
                CustomerName = EntName.Text,
                Email = EntEmail.Text,
                Phone = EntPhone.Text,
                Qty = SpanQty.Text,
                MovieName = LblMovieName.Text,
                TotalPayment = SpanTotalPrice.Text,
                BookingDate = bookingTime
            };
            ApiServices apiServices = new ApiServices();
            bool response = await apiServices.Order(bookTicket);
            if (!response)
            {
                await DisplayAlert("Oops", "Something went wrong...", "Alright");
            }
            else
            {
                await DisplayAlert("Hi", "Your ticket has been reserved...", "Alright");
                await Navigation.PopAsync();
            }
        }

        private void PickerQty_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var qty = PickerQty.Items[PickerQty.SelectedIndex];
            SpanQty.Text = qty;
            double price = Convert.ToDouble(SpanAmount.Text);
            double totalPrice = Convert.ToDouble(qty) * price;
            SpanTotalPrice.Text = totalPrice.ToString();
        }
    }
}