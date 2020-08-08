using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doctus_Prueba.Models
{
    [Table("Tip")]
    public class Tip
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [MaxLength(30)]
        public string Titulo { get; set; }

        [MaxLength(150)]
        public string Descripcion { get; set; }
        
        public DateTime FechaCreacion { get; set; }
    }
}
