using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiRest.Models
{
    [Table("TipoVehiculo")]
    public partial class TipoVehiculo
    {
        public TipoVehiculo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        [Key]
        public int TipoVehiculoId { get; set; }
        [Required]
        [StringLength(50)]
        public string NombreTipoVeh { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [InverseProperty(nameof(Vehiculo.TipoVehiculo))]
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
