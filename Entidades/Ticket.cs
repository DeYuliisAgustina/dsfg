using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ticket
    {
        public enum Categoria { hardware, software, red }
        public enum Tipo { servicio, incidencia }
        public enum Estado { abierto, progreso, resuelto }
        public enum Urgencia { critica, alta, media, baja }

        public int TicketId { get; set; }

        public int ComputadoraId { get; set; } //FK
        public Computadora Computadora { get; set; } //un ticket pertenece a una computadora
        public string Ubicacion { get; set; }
        public string NombreSede { get; set; }

        public DateTime FechaCreacion { get; set; }
        public string? DescripcionTicket { get; set; }

        public int TecnicoId { get; set; } //FK
        public Tecnico Tecnico { get; set; } //un ticket pertenece a un tecnico

        public Categoria categoria { get; set; }
        public Urgencia urgencia { get; set; }
        public Estado estado { get; set; }
        public Tipo tipo { get; set; }

        public ICollection<Laboratorio> Laboratorios { get; set; } = new List<Laboratorio>();

        public override string ToString()
        {
            return Computadora.CodigoComputadora;
        }
    }
}
