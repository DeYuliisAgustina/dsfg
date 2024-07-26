using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sede
    {

        public int SedeId { get; set; }
        public string NombreSede { get; set; }
        public string DireccionSede { get; set; }

        public int UniversidadId { get; set; }
        public Universidad Universidad { get; set; }

        public ICollection<Laboratorio> Laboratorios { get; set; } = new List<Laboratorio>();

        public override string ToString()
        {
            return NombreSede;
        }
    }
}
