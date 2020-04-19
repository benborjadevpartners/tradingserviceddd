using System;
using System.Collections.Generic;
using System.Text;
using TradingEngine.Domain.Interfaces;

namespace TradingEngine.Domain.Service
{
    public class UserAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        public UserAuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsUserAuthenticated(string username, string password)
        {
            return _userRepository.AuthenticateUser(username, password);
        }
    }
}
