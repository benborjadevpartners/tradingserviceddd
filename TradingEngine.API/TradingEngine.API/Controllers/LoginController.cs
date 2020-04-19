using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TradingEngine.Domain.Service;

namespace TradingEngine.API.Controllers
{
    public class LoginController : ApiController
    {
        private readonly UserAuthenticationService _userAuthenticationService;
        public LoginController(UserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        [HttpPost]
        public IHttpActionResult Index(string username,string password)
        {
            var result = _userAuthenticationService.IsUserAuthenticated(username, password);
            return Ok(result);
        }



    }
}