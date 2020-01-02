
using DataAccessLayer.Models;
using System;


namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Point> PointesRepository { get; }
        IRepository<UserData> UserDatasRepository { get; }
        void Save();
    }
}
