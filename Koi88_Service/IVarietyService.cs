using Koi88_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_Service
{
     public interface IVarietyService
    {
        List<Variety> GetVarieties();
        Variety GetVarietyById(int id);
    }

}
