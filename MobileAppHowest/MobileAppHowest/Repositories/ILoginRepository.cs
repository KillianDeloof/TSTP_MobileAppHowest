using MobileAppHowest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppHowest.Repositories
{
    public interface ILoginRepository
    {
        Task<UserInfo> Login();
    }
}
