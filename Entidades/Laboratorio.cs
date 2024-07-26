using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Laboratorio
    {
        public int LaboratorioId { get; set; }
        public string NombreLaboratorio { get; set; }
        public int CapacidadMaxima { get; set; }

        public int SedeId { get; set; }
        public Sede Sede { get; set; }

        public ICollection<Computadora> Computadoras { get; set; } = new List<Computadora>();

        public override string ToString()
        {
            return NombreLaboratorio;
        }
    }
}
