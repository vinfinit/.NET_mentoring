using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1_1("Beverages");
        }

        static void Task1_1(string category)
        {
            using (var db = new EntityDataModel())
            {
                var orders = db.Orders
                    .Where(o => o.Order_Details.Any(d => d.Product.Category.CategoryName == category))
                    .ToList();
                Console.WriteLine();
            }
        }
    }
}
