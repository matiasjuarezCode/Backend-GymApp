using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGym.Service.Interface
{
    public interface ISegurityRepository
    {
        Task<bool> Login(string username, string password);

        Task<bool> VerifyExists(string username);

    }
}
