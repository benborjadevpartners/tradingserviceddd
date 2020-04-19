using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingEngine.Domain.Entities;
using TradingEngine.Domain.Interfaces;
using TradingEngine.Infrastructure.Data;

namespace TradingEngine.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TradingEngineContext _context;
        public UserRepository(TradingEngineContext context)
        {
            _context = context;
        }

        public bool AuthenticateUser(string username, string password)
        {
            var match = _context.Users.Where(u => u.Username.Equals(username) && u.Password.Equals(password)).FirstOrDefault();
            return match == null ? false: true;
        }

        public User FindByUsername(string username)
        {
            return _context.Users.Where(u => u.Username.Equals(username)).FirstOrDefault();
        }

        public void Save(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
