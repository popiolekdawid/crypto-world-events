using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication1.Entities;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        AuthenticationResponse
        Authenticate(AuthenticationRequest request);
        IEnumerable<User> GetUsers();
        User GetByUsername(string username);
        User GetById(int id);
        public List<User> GetAllUsers();

    }
}
