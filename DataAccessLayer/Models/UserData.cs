

using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class UserData
    {
        public int Id { get; set; }
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }
        public int Step { get; set; }
        public int CoefficientSecondDegrees { get; set; }
        public int CoefficientFirstDegrees { get; set; }
        public int CoefficientZeroDegrees { get; set; }
        public IList<Point> PointList { get; set; }

        public UserData()
        {
            PointList = new List<Point>();
        }
    }
}
