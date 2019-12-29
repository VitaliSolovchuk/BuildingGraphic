using DataAccessLayer.EntityF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DataAccessLayer.Repositories
{
    public class PointRepository : IRepository<Point>
    {
        private GraphicContext db;

        public PointRepository(GraphicContext graphicContext)
        {
            this.db = graphicContext;
        }

        public IEnumerable<Point> GetAll()
        {
            return db.Points;
        }

        public Point Get(int id)
        {
            return db.Points.Find(id);
        }

        public IEnumerable<Point> Find(Func<Point, bool> predicate)
        {
            return db.Points.Where(predicate).ToList();
        }

        public void Create(Point item)
        {
            db.Points.Add(item);
        }

        public void Update(Point item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Point point = db.Points.Find(id);
            if ( point != null)
            {
                db.Points.Remove(point);
            }
        }

    }
}
