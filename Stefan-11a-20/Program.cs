using Stefan_11a_20.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stefan_11a_20
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console, Form");
            string start = Console.ReadLine();
            if (start == "Form")
            {
                ShoeForm form = new ShoeForm();
                Application.Run(form);
            }
            else
            {
                Display s = new Display();
                s.ShowMenu();
            }

        }
    }
}
