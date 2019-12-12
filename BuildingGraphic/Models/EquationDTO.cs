

using System.ComponentModel.DataAnnotations;

namespace BuildingGraphic.Models
{
    public class EquationDTO : Equation
    {
        [Display(Name = "from")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        //[StringLength(5, MinimumLength = 1, ErrorMessage = "Братан, я не супе ПК. Уменьши запросы=)")]
        //[RegularExpression(@"[0-9]", ErrorMessage = "Некорректныая точка")]
        public float StartPosition { get; set; }

        [Display(Name = "to")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        //[StringLength(5, MinimumLength = 1, ErrorMessage = "Братан, я не супе ПК. Уменьши запросы=)")]
        //[RegularExpression(@"[0-9]", ErrorMessage = "Некорректныая точка")]
        
        public float StopPosition { get; set; }
        [Display(Name = "step")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        //[StringLength(5, MinimumLength = 1, ErrorMessage = "Братан, я не супе ПК. Уменьши запросы=)")]
        //[RegularExpression(@"[0-9]", ErrorMessage = "Некорректный шаг")]
        public float Step { get; set; }

    }
}