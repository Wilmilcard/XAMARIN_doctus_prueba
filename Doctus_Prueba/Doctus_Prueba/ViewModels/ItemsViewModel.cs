using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Doctus_Prueba.Models;
using Doctus_Prueba.Views;
using Doctus_Prueba.Reporsitory;
using System.Collections.Generic;

namespace Doctus_Prueba.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private ObservableCollection<Tip> tipList;
 
        public ObservableCollection<Tip> TipsList { get { return tipList; } set { tipList = value; OnPropertyChanged("TipsList"); } }
        public Command LoadTipsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Tips";

            this.TipsList = new ObservableCollection<Tip>();
            this.TipsList = TipsRepository.Tips_Repository.GetAllTips();

            this.LoadTipsCommand = new Command(async () => await ExecuteLoadTipsCommand());
        }

        async Task ExecuteLoadTipsCommand()
        {
            IsBusy = true;

            try
            {
                this.TipsList.Clear();
                this.TipsList = TipsRepository.Tips_Repository.GetAllTips();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void Cargar()
        {
            await this.ExecuteLoadTipsCommand();
        }
    }
}