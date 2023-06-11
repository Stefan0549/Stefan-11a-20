using Stefan_11a_20.Controller;
using Stefan_11a_20.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefan_11a_20.View
{
    public class Display
    {
        private int closeOperationId = 6;
        public ShoeLogic shoLogic = new ShoeLogic();
        public Display()
        {
            Input();
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        public void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            shoLogic.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Shoe sho = shoLogic.Get(id);
            if (sho != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + sho.Id);
                Console.WriteLine("Name: " + sho.Brand);
                Console.WriteLine("Number: " + sho.Size);
                Console.WriteLine("Price: " + sho.Price);
                Console.WriteLine("Type: " + sho.Type);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Shoe sho = shoLogic.Get(id);

            // List<VegetableLogic> typeVeg = new List<VegetableLogic>();


            if (sho != null)
            {
                Console.WriteLine("Enter name: ");
                sho.Brand = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                sho.Price = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter availability: ");
                sho.TypeId = int.Parse(Console.ReadLine());
                shoLogic.Updates(id, sho);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void Add()
        {
            Shoe sho = new Shoe();
            Console.WriteLine("Enter name: ");
            sho.Brand = Console.ReadLine();
            Console.WriteLine("Enter number: ");
            sho.Size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter price: ");
            sho.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter type: ");
            sho.TypeId = int.Parse(Console.ReadLine());
            shoLogic.Create(sho);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "PRODUCTS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var sho = shoLogic.GetAll();
            foreach (var item in sho)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.Id, item.Brand, item.Price, item.Size);
            }
        }
    }
}
