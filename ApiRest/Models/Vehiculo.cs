using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiRest.Models
{
    [Table("Vehiculo")]
    public partial class Vehiculo
    {
        [Key]
        public int VehiculoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Modelo { get; set; }

        [Required]
        public short Agno { get; set; }

        [Required]
        public double Cilindraje { get; set; }

        [Required]
        public int TipoVehiculoId { get; set; }

        [Required]
        public int MarcaId { get; set; }

        [ForeignKey(nameof(MarcaId))]
        [InverseProperty("Vehiculos")]
        public virtual Marca Marca { get; set; }
        [ForeignKey(nameof(TipoVehiculoId))]
        [InverseProperty("Vehiculos")]
        public virtual TipoVehiculo TipoVehiculo { get; set; }
    }
}
