using System;

using Doctus_Prueba.Models;

namespace Doctus_Prueba.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Tip Item { get; set; }
        public ItemDetailViewModel(Tip tip = null)
        {
            Title = tip?.Titulo;
            Item = tip;
        }
    }
}
