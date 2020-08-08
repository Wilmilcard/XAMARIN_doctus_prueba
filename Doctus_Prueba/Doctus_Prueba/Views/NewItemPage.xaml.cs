using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Doctus_Prueba.Models;
using Doctus_Prueba.Reporsitory;

namespace Doctus_Prueba.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Tip Tip { get; set; }
        public bool isEdith { get; set; }

        public NewItemPage(Tip tip_editar = null)
        {
            InitializeComponent();

            this.Tip = tip_editar;
            this.TxtTitulo.Text = this.Tip == null ? "" : this.Tip.Titulo;
            this.TxtDescipcion.Text = this.Tip == null ? "" : this.Tip.Descripcion;
            this.isEdith = this.Tip == null ? false : true;

            BindingContext = this;
        }

        async void Insertar_Tip(object sender, EventArgs e)
        {
            try
            {
                if (this.isEdith)
                {
                    this.Tip = new Tip { Id = this.Tip.Id, Titulo = TxtTitulo.Text, Descripcion = TxtDescipcion.Text, FechaCreacion = this.Tip.FechaCreacion };
                    TipsRepository.Tips_Repository.UpdateTip(this.Tip);
                    await DisplayAlert("Editado", $"El Tip {this.Tip.Id} actualizado", "OK");
                }
                else
                {
                    TipsRepository.Tips_Repository.AddTip(TxtTitulo.Text, TxtDescipcion.Text);
                    await DisplayAlert("Editado", $"Tip creado", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}