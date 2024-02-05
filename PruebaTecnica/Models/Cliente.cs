using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models
{
    public partial class Cliente
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? PatenteComercio { get; set; }
        public string? VehiculoAsignado { get; set; }
        public decimal? PorcentajeCargo { get; set; }
        public string? DireccionCarga { get; set; }
        public string? DireccionEntregaCarga { get; set; }
        public string? DocumentacionCarga { get; set; }
        public long? IdVehiculo { get; set; }

        public virtual Vehiculo? IdVehiculoNavigation { get; set; }
    }
}
