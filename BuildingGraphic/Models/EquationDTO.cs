

using System.ComponentModel.DataAnnotations;

namespace BuildingGraphic.Models
{
    public class EquationDTO : Equation
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "from")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "Братан, я не супе ПК. Уменьши запросы=)")]
        [RegularExpression(@"[0-9]", ErrorMessage = "Некорректныая точка")]
        public float StartPosition { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "to")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "Братан, я не супе ПК. Уменьши запросы=)")]
        [RegularExpression(@"[0-9]", ErrorMessage = "Некорректныая точка")]
        public float StopPosition { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "step")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Братан, я не супе ПК. Уменьши запросы=)")]
        [RegularExpression(@"[0-9]", ErrorMessage = "Некорректный шаг")]
        public float Step { get; set; }

    }
}