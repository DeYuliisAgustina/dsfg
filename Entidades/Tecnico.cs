using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tecnico
    {

        public int TecnicoId { get; set; }
        public string NombreyApellido { get; set; }
        public long Dni { get; set; }
        public string Legajo { get; set; }
        public int CantidadTickets { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>(); //un soporte puede tener muchos tickets

        public override string ToString()
        {
            return NombreyApellido; //muestro el nombre y apellido del tecnico
        }
    }
}
