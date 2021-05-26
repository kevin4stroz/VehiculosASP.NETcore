using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiRest.Models
{
    [Table("Marca")]
    public partial class Marca
    {
        public Marca()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        [Key]
        public int MarcaId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [InverseProperty(nameof(Vehiculo.Marca))]
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
