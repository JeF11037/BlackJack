using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlackJack
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Game();
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
