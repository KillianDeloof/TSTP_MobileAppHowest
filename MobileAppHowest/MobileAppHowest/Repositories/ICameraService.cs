using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//remove this file if takepickture works whitout chomado's code
namespace MobileAppHowest.Repositories
{
    public interface ICameraService
    {
        Task<byte[]> TakePhotosAsync();
    }
}
