using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppHowest.Models.MobileSDK
{
    public interface IAuthenticate
    {
        string LoginMessage { get; set; }
        Task<bool> Authenticate();
    }
}
