using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Doctus_Prueba.Models;
using SQLite;

namespace Doctus_Prueba.Reporsitory
{
    public class TipsRepository
    {
        private SQLiteConnection con;
        private static TipsRepository tipsRepository;
        public string response;
        public static TipsRepository Tips_Repository { get { if (tipsRepository == null) throw new Exception("Error al instanciar"); return tipsRepository; } }
        
        public static void Iniciar(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException();

            if (tipsRepository != null)
                tipsRepository.con.Close();
            tipsRepository = new TipsRepository(fileName);
        }

        private TipsRepository(string path)
        {
            this.con = new SQLiteConnection(path);
            this.con.CreateTable<Tip>();
        }

        public ObservableCollection<Tip> GetAllTips()
        {
            try
            {
                return new ObservableCollection<Tip>(this.con.Table<Tip>()); ;
            }
            catch (Exception ex)
            {
                this.response = ex.Message;
            }
            return new ObservableCollection<Tip>();
        }

        public int AddTip(string _titulo, string _desc)
        {
            int rpta = 0;
            try
            {
                rpta = con.Insert(new Tip() { Titulo = _titulo, Descripcion = _desc, FechaCreacion = DateTime.Now });
                this.response = string.Format($"Filas Agregadas --> {rpta}");
            }
            catch (Exception ex)
            {
                this.response = ex.Message;
            }
            return rpta;
        }

        public int UpdateTip(Tip _tip)
        {
            int rpta = 0;
            try
            {
                rpta = con.Update(_tip);
                this.response = string.Format($"Filas Actualizadas --> {rpta}");
            }
            catch(Exception ex)
            {
                this.response = ex.Message;
            }
            return rpta;
        }
        
        public void DeleteTip(Tip _tip)
        {
            try
            {
                var rpta = con.Delete(_tip);
            }
            catch (Exception ex)
            {
                this.response = ex.Message;
            }
        }
    }
}
