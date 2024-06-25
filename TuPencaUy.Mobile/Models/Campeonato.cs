using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuPencaUy.Mobile.Models
{
    public class Campeonato
    {
        public int Id { get; set; }            // Identificador único del campeonato
        public string Nombre { get; set; }     // Nombre del campeonato
        public string Descripcion { get; set; } // Descripción del campeonato (opcional)
        public DateTime FechaInicio { get; set; } // Fecha de inicio del campeonato (opcional)
        public DateTime FechaFin { get; set; } // Fecha de fin del campeonato (opcional)
        public string Ubicacion { get; set; }  // Ubicación del campeonato (opcional)
        public string ImagenUrl { get; set; }  // URL de la imagen del campeonato (opcional)
    }
}
