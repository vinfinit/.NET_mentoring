using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types2
{
    class Program
    {
        static void Main(string[] args)
        {
            var listProduct = new List<Product>();
            var milk = new Product("milk", 10, 24);
            listProduct.Add(milk);
        }

    }

    public struct Product
    {
        public readonly string name;
        public readonly int count;
        public readonly int cost;

        public Product(string name, int count, int cost)
        {
            this.name = name;
            this.count = count;
            this.cost = cost;
        }
    }
}
