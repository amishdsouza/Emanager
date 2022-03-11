using Demo.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Services
{
    public interface IAuthenticateService
    {
        User Authenticate(string userName, string password);
    }
}
