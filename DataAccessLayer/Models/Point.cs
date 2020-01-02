

namespace DataAccessLayer.Models
{
    public class Point
    {
        public int Id { get; set; }
        public int UserDataId { get; set; }
        public UserData UserData { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
    }
}
