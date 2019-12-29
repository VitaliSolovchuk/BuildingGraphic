using DataAccessLayer.EntityF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DataAccessLayer.Repositories
{
    public class UserDataRepository : IRepository<UserData>
    {
        private GraphicContext db;

        public UserDataRepository(GraphicContext graphicContext)
        {
            this.db = graphicContext;
        }

        public IEnumerable<UserData> GetAll()
        {
            return db.UserDatas;
        }

        public UserData Get(int id)
        {
            return db.UserDatas.Find(id);
        }

        public IEnumerable<UserData> Find(Func<UserData, bool> predicate)
        {
            return db.UserDatas.Where(predicate).ToList();
        }

        public void Create(UserData item)
        {
            db.UserDatas.Add(item);
        }

        public void Update(UserData item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            UserData userData = db.UserDatas.Find(id);
            if (userData != null)
            {
                db.UserDatas.Remove(userData);
            }
        }

    }
}
