using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateDTO;

namespace RealEstateDAL
{
    internal interface IRealEstateDAL
    {
        Estate LoadEstate(string path);

        bool SaveEstate(string path, Estate estates);
    }
}
