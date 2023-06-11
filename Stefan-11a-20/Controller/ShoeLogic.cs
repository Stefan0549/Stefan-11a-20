using Stefan_11a_20.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefan_11a_20.Controller
{
    public class ShoeLogic
    {
        private ShoeContext shoContext = new ShoeContext();
        public Shoe Get(int id)
        {
            Shoe findSho = shoContext.Shoes.Find(id);
            if (findSho != null)
            {
                shoContext.Entry(findSho).Reference(x => x.Type).Load();

            }
            return findSho;

        }
        public List<Shoe> GetAll()
        {
            return shoContext.Shoes.Include("Type").ToList();
        }
        public void Create(Shoe sho)
        {
            shoContext.Shoes.Add(sho);
            shoContext.SaveChanges();
        }
        public void Updates(int id, Shoe sho)
        {
            Shoe findSho = shoContext.Shoes.Find(id);
            if (findSho == null)
            {
                return;
            }
            findSho.Brand = sho.Brand;
            findSho.Size = sho.Size;
            findSho.Price = sho.Price;
            findSho.Discription = sho.Discription;
            findSho.Type = sho.Type;
            shoContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Shoe findSho = shoContext.Shoes.Find(id);
            shoContext.Shoes.Remove(findSho);
            shoContext.SaveChanges();
        }
    }
}
