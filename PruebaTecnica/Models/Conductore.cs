using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public partial class Conductore
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Dpi { get; set; }
        public bool? LicenciaVigente { get; set; }
        public string? NoLicencia { get; set; }
        [Display(Name = "Disponible")]
        public bool Disponibilidad { get; set; }
        public TimeSpan? TiempoRequerido { get; set; }
        public TimeSpan? TiempoAyudantes { get; set; }
        public decimal? ViaticosEquipo { get; set; }
        public decimal? GastosRequeridos { get; set; }
        public long IdVehiculo { get; set; }

        public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
    }
}
