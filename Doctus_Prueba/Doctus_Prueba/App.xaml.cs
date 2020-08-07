using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Doctus_Prueba.Services;
using Doctus_Prueba.Views;
using Doctus_Prueba.Reporsitory;

namespace Doctus_Prueba
{
    public partial class App : Application
    {

        public App(string filename)
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            TipsRepository.Iniciar(filename);
            MainPage = new MainPage();
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
