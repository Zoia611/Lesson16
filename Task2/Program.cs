using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            double maxPrice = products[0].Price;
            string maxName = products[0].Name;

            foreach (Product p in products)
            {
                if (p.Price > maxPrice)
                {
                    maxName = p.Name;
                }
            }
            Console.WriteLine($"Самый дорогой товар {maxName}");
            Console.ReadKey();
        }
    }
}
