
using DataAccessLayer.Models;
using System.Data.Entity;

namespace DataAccessLayer.EntityF
{
    public class GraphicContext : DbContext
    {
        public DbSet<Point> Points { get; set; }
        public DbSet<UserData> UserDatas { get; set; }

        static GraphicContext()
        {
            Database.SetInitializer<GraphicContext>(new GraphicContextInitializer());
        }

        public GraphicContext(string connectionString) : base(connectionString){}

    }

    public class GraphicContextInitializer : DropCreateDatabaseIfModelChanges<GraphicContext>
    {
        protected override void Seed(GraphicContext db)
        {
            db.UserDatas.Add(new UserData() { Id = 1, CoefficientSecondDegrees = 1, CoefficientFirstDegrees = 1, CoefficientZeroDegrees = 1, RangeFrom = 1, RangeTo = 2, Step = 1 });
            db.Points.Add(new Point() { Id = 1, PointX = 1, PointY = 1, UserDataId = 1 });
            db.Points.Add(new Point() { Id = 2, PointX = 1, PointY = 2, UserDataId = 1 });
            db.SaveChanges();
        }
    }
}
