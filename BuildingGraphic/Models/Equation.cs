

using System.ComponentModel.DataAnnotations;

namespace BuildingGraphic.Models
{
    public class Equation
    {
        [Required]
        [Display(Name = "Coefficient x^2")]
        public float CoefficientZeroDegrees { get; set; }
        [Required]
        [Display(Name = "Coefficient x^1")]
        public float CoefficientFirstDegrees { get; set; }
        [Required]
        [Display(Name = "Coefficient x^0")] 
        public float CoefficientSecondDegrees { get; set; }
    }
}