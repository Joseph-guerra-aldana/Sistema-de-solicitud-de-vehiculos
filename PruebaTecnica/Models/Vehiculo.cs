using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Clientes = new HashSet<Cliente>();
            Conductores = new HashSet<Conductore>();
        }

        public long Id { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Nombre { get; set; }
        public string? Placas { get; set; }
        public int? Capacidad { get; set; }
        public string? Combustible { get; set; }
        public string? Ubicacion { get; set; }
        public bool Disponibilidad { get; set; }
        public decimal? Depreciacion { get; set; }
        public string? TipoCarga { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Conductore> Conductores { get; set; }
    }
}
