using System;

using Doctus_Prueba.Models;

namespace Doctus_Prueba.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Tip Item { get; set; }
        public ItemDetailViewModel(Tip item = null)
        {
            Title = item?.Titulo;
            Item = item;
        }
    }
}
