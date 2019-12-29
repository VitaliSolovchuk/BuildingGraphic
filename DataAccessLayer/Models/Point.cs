using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Point
    {
        public int PointId { get; set; }
        public int ChartId { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
    }
}
