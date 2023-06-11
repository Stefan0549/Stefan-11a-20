using Stefan_11a_20.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefan_11a_20.Controller
{
    public class TypeLogic
    {
        private ShoeContext _shoContext = new ShoeContext();

        public List<ShoeType> GetAllTypes()
        {
            return _shoContext.ShoesTypes.ToList();
        }
        public string GetTypeById(int id)
        {
            return _shoContext.ShoesTypes.Find(id).Name;
        }
    }
}
