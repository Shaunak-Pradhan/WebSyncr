using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPortal.Services.Interface
{
    public interface IAuthService
    {
        bool IsValidUser(string username, string password);
        bool EnableAuth();
    }
}
