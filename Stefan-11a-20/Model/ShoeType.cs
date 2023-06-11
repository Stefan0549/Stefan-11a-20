using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefan_11a_20.Model
{
    public class ShoeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Shoe> Shoes { get; set; }
    }
}
