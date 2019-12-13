

using System.ComponentModel.DataAnnotations;

namespace BuildingGraphic.Models
{
    public class Equation
    {
        [Display(Name = "Coefficient x^0")] 
        [Required]
        public float CoefficientZeroDegrees { get; set; }

        [Display(Name = "Coefficient x^1")]
        [Required]
        public float CoefficientFirstDegrees { get; set; }
        
        [Display(Name = "Coefficient x^2")]
        [Required]
        public float CoefficientSecondDegrees { get; set; }
    }
}