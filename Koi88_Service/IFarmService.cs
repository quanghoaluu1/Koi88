using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;

namespace Koi88_Service
{
    public interface IFarmService
    {
        List<KoiFarm> GetFarms();
    }
}
