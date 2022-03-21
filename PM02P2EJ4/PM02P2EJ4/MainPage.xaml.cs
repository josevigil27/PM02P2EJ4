using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PM02P2EJ4.Models;
using PM02P2EJ4.Views;
using Xam.Forms.VideoPlayer;
using Xamarin.Essentials;
using System.IO;

namespace PM02P2EJ4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public string VideoPath;

        public MainPage()
        {
            InitializeComponent();
        }

        private void videoplayer_PlayCompletion(object sender, EventArgs e)
        {
            
        }

        private async void btngrabarvideo_Clicked(object sender, EventArgs e)
        {
            try
            {
                var video = await MediaPicker.CaptureVideoAsync();
                await LoadPhotoAsync(video);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {VideoPath}");
                //await DisplayAlert("as", PhotoPath, "ok");

                UriVideoSource uriVideoSource = new UriVideoSource()
                {
                    Uri = VideoPath
                };

                videoplayer.Source = uriVideoSource;
            }
            catch (FeatureNotSupportedException)
            {
            }
            catch (PermissionException)
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        private async void btnguardarvideo_Clicked(object sender, EventArgs e)
        {
            var videos = new Video
            {
                Uri = VideoPath,
                Descripcion = descripcion_entry.Text
            };

            var resultado = await App.BDO.SaveVideo(videos);

            if (resultado == 1)
            {
                await DisplayAlert("Alerta", "Video Guardado", "Ok");
                descripcion_entry.Text = "";
                videoplayer.Source = null;

                await Navigation.PushAsync(new ListViewPage());
            }
            else
            {
                await DisplayAlert("Alerta", "No se pudo Guardar", "Ok");
            }
        }

        private async void btnlistviewpage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListViewPage());
        }

        private void btnsalirapp_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        async Task LoadPhotoAsync(FileResult video)
        {
            if (video == null)
            {
                VideoPath = null;
                return;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, video.FileName);
            using (var stream = await video.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);
            VideoPath = newFile;
        }
    }
}
