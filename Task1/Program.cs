using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Unicode;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 3;
            Product[] products = new Product[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Код товара");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Название товара");
                string name = Console.ReadLine();
                Console.WriteLine("Цена товара");
                double price = Convert.ToDouble(Console.ReadLine());
                products[i] = new Product() { Code = code, Name = name, Price = price };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(products, options);

            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}
