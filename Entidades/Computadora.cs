using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Ticket;

namespace Entidades
{
    public class Computadora
    {
        public enum EstadoComputadora { actualizada, error, rota, soporteTecnico, freezada }
        public enum CondicionComputadora { hardware, software, red }

        public int ComputadoraId { get; set; }
        public string CodigoComputadora { get; set; }

        public int LaboratorioId { get; set; } //FK
        public Laboratorio Laboratorio { get; set; } //una computadora pertenece a un laboratorio

        public string NombreSede { get; set; } //FK    

        public string DescripcionComputadora { get; set; }
        public EstadoComputadora estado { get; set; }
        public CondicionComputadora condicion { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>(); //una computadora puede tener muchos tickets

        public override string ToString()
        {
            return CodigoComputadora; //muestro el codigo de la computadora
        }
    }
}
