using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM02P2EJ4.Models;
using PM02P2EJ4.Views;

namespace PM02P2EJ4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();
            Listview_VideoList();
        }

        private async void listviewvideo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listviewvideo.SelectedItem = null;

            try
            {
                Video item = (Video)e.SelectedItem;
                var playvideopage = new VideoPlayPage(item);
                playvideopage.BindingContext = item;
                await Navigation.PushAsync(playvideopage);
            }
            catch (Exception ex)
            {
                // await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {

        }

        public async void Listview_VideoList()
        {
            var listview = await App.BDO.GetVideoList();
            listviewvideo.ItemsSource = listview;
        }
    }
}