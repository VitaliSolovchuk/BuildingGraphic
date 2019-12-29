
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
            //Database.SetInitializer<GraphicContext>(new GraphicContextInitializer());
        }

        public GraphicContext(string connectionString) : base(connectionString){}

    }
}
