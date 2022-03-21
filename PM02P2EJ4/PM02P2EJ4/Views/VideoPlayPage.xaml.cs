using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM02P2EJ4.Models;
using Xam.Forms.VideoPlayer;

namespace PM02P2EJ4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPlayPage : ContentPage
    {
        public VideoPlayPage( Video datos )
        {
            InitializeComponent();

            lbldescripcion.Text = datos.Descripcion;
            UriVideoSource uriVideoSurce = new UriVideoSource()
            {
                Uri = datos.Uri
            };
            videoplay.Source = uriVideoSurce;
        }

        private void videoplayer_PlayCompletion(object sender, EventArgs e)
        {

        }

        private async void btnvolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}