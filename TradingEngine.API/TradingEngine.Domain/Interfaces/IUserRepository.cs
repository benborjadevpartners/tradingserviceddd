using System;
using System.Collections.Generic;
using System.Text;
using TradingEngine.Domain.Entities;

namespace TradingEngine.Domain.Interfaces
{
    public interface IUserRepository
    {
        User FindByUsername(string username);
        bool AuthenticateUser(string username, string password);

        void Save(User user);
    }
}
