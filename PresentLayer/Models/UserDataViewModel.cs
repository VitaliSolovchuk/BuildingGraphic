using System.Collections.Generic;


namespace PresentLayer.Models
{
    public class UserDataViewModel
    {
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }
        public int Step { get; set; }
        public int CoefficientSecondDegrees { get; set; }
        public int CoefficientFirstDegrees { get; set; }
        public int CoefficientZeroDegrees { get; set; }
        public ICollection<PointViewModel> PointList { get; set; }
    }
}