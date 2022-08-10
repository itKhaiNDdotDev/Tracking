using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Backend.DTOs.User;

namespace Tracking.Backend.Services.Auth
{
    public interface IUsers
    {
        Task<AuthViewModel> Login(string email, string password/*, bool rememberMe*/);
        Task<bool> Register(RegisterRequest request);
        Task Logout();
    }
}
