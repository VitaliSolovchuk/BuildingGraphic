using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PresentLayer.Models
{
    public class UserDataViewModel
    {
        [Required]
        public int RangeFrom { get; set; }

        public int RangeTo { get; set; }

        public int Step { get; set; }

        public int CoefficientSecondDegrees { get; set; }

        public int CoefficientFirstDegrees { get; set; }
 
        public int CoefficientZeroDegrees { get; set; }

        public IList<PointViewModel> PointList { get; set; }
    }
}