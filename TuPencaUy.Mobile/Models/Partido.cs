using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuPencaUy.Mobile.Models
{
    public class Partido
    {
        public int Id { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }  // Puede ser "Pendiente", "Ganó Local", "Ganó Visitante", "Empate"
    }
}
