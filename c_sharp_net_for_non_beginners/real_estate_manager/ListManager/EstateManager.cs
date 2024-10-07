using real_estate_manager.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace real_estate_manager.ListManager
{
    public class EstateManager : ListManager<Estate>
    {
        public EstateManager() :base() { }

        public override string[] ToStringArray()
        {
           var estateArray = new string[_list.Count];

            for(int i = 0; i<_list.Count; i++)
            {
                estateArray[i] = _list[i].ToString();
            }
            return estateArray;
        }

        public List<int> GetIds()
        {
            var list = new List<int>();

            foreach (Estate estate in _list)
            {
                list.Add(estate.Id);
            }

            return list;
        }

        public List<Estate> GetAllEStates()
        {
            var list = new List<Estate>();

            foreach (Estate estate in _list)
            {
                list.Add(estate);
            }
            return list;
        }

    }
}
