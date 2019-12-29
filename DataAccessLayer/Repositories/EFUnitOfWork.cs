using DataAccessLayer.EntityF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;

namespace DataAccessLayer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private GraphicContext db;
        private UserDataRepository userDataRepository;
        private PointRepository pointRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new GraphicContext(connectionString);
        }

        public IRepository<UserData> UserDatasRepository
        {
            get
            {
                if (userDataRepository == null)
                    userDataRepository = new UserDataRepository(db);
                return userDataRepository;
            }
        }

        public IRepository<Point> PointesRepository
        {
            get
            {
                if (pointRepository == null)
                    pointRepository = new PointRepository(db);
                return pointRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposed)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
