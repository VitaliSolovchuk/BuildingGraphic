

namespace DataAccessLayer.Models
{
    public class UserData
    {
        public int UserDataId { get; set; }
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }
        public int CoefficientSecondDegrees { get; set; }
        public int CoefficientFirstDegrees { get; set; }
        public int CoefficientZeroDegrees { get; set; }
        public int Step { get; set; }
    }
}
