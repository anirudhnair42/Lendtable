using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SQLitePCL;

namespace FinalSolution
{
    public class DatabaseAccess : IDatabaseAccess
    {
        private readonly Models.TradingContext _context;
        
        public DatabaseAccess(Models.TradingContext context)
        {
            _context = context;
        }
        public void RegisterUser(string name)
        {
            _context.Add(new Models.Identity { Name = name }); 
             _context.SaveChanges();
             
        }

        public Models.Identity GetUser(int id)
        {
            var user = _context.Identitys.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentException("Id Doesn't Exist");
            }
            return user;
           
        }
        
    }

    public interface IDatabaseAccess
    {
        void RegisterUser(string name);

        Models.Identity GetUser(int id);
        
    }
}