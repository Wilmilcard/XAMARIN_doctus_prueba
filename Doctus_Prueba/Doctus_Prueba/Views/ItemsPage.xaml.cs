using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Doctus_Prueba.Models;
using Doctus_Prueba.Views;
using Doctus_Prueba.ViewModels;
using Doctus_Prueba.Reporsitory;

namespace Doctus_Prueba.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void AddTip(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void SelectedTip(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var tip = (Tip)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(tip)));
        }

        private async void DeleteTip(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var tip = (Tip)layout.BindingContext;
            try
            {
                TipsRepository.Tips_Repository.DeleteTip(tip);
                await DisplayAlert("Eliminado", $"El tip {tip.Titulo} eliminado", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
            this.viewModel.Cargar();
        }

    }
}