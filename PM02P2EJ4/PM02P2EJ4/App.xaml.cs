using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM02P2EJ4.Controllers;

namespace PM02P2EJ4
{
    public partial class App : Application
    {
        static VideoDB BaseDatos;

        public static VideoDB BDO
        {
            get
            {
                if (BaseDatos == null)
                {
                    BaseDatos = new VideoDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VideoDB.db3"));
                }
                return BaseDatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
