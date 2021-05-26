using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models.CustomModels
{
    [NotMapped]
    public class DivisionOperadores
    {
        [Required(ErrorMessage="Num1 es requerido")]
        public float Num1 { get; set; }

        [Required(ErrorMessage="Num2 es requerido")]
        [RequiredGreaterThanZero(ErrorMessage="Num2 diferente que 0")]
        public float Num2 { get; set; }

        public float Result { 
            get { return Num1 / Num2; } 
        }
    }

    public class RequiredGreaterThanZero : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            float i;
            return value != null && float.TryParse(value.ToString(), out i) && i > 0;
        }
    }    
}

