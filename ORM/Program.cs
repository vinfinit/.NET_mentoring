using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Model;

namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintCollection(DbNorthwind.Task2_1());
            DbNorthwind.Task2_2();
            DbNorthwind.Task2_3();
            DbNorthwind.Task3_2();
            Console.ReadLine();
        }

        public static void PrintCollection(IEnumerable<Product> products)
        {
            foreach (var p in products)
            {
                Console.WriteLine(p.Name, p.Category.CategoryName, p.Supplier.CompanyName);
            }
            Console.WriteLine(products.Count());
            Console.WriteLine();
        }
    }
}
