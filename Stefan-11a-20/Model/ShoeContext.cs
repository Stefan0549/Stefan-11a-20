using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefan_11a_20.Model
{
    public class ShoeContext:DbContext
    {
        public ShoeContext() : base("ShoeContext") { }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeType> ShoesTypes { get; set; }
    }
}
