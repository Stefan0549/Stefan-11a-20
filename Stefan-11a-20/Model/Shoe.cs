using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefan_11a_20.Model
{
    public class Shoe
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Size { get; set; }
        public double Price { get; set; }
        public string Discription { get; set; }
        public int TypeId { get; set; }
        public ShoeType Type { get; set; }
    }
}
