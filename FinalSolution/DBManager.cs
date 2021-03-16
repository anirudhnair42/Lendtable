using System;

namespace FinalSolution
{
    public class DBManager : IDBManager
    {
        private readonly IDatabaseAccess _dbAccess;
        public DBManager(IDatabaseAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }
        public Models.Identity GetUser(int id)
        {
            var user = _dbAccess.GetUser(id);

            if (user == null)
            {
                throw new Exception("Invalid user");
            }
            return user;
        }
    }

    public interface IDBManager
    {
        Models.Identity GetUser(int id);
    }
}