using LINQ.DataSources;
using Linq01.Models;

namespace Linq01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = Source.ProductList;
            List<Customer> customers = Source.CustomerList;


            /*Q1*/

            spacing(1);
            List<Product> SeaFood = products.Select(x => x).Where(x => x.Category == "Seafood").ToList();
            
            foreach(Product p in SeaFood)
            {
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            }

            /*Q2*/
            spacing(2);

            List<string> productNames = products.Select(x => x.ProductName).ToList();
            foreach (string p in productNames)
            {
                Console.WriteLine($"ProductName: {p}");
            }

            /*Q3*/
            spacing(3);

            List<Product> AscProduct = products.Select(x => x).OrderBy(x=>x.UnitPrice).ToList();

            foreach(Product p in AscProduct)
            {
                Console.WriteLine($"{p.ProductName}-{p.UnitPrice}");

            }

            /*Q4*/

            List<Product> FilterProductByPrice = products.Select(x => x).Where(x => 10 < x.UnitPrice && x.UnitPrice < 30).ToList();

            /*Q5*/

            List<Product> FilterProductByUnitStock = products.Select(x => x).Where(x => x.UnitsInStock>0&&x.Category== "Condiments").ToList();

            /*Q6*/
            spacing(6);
            var result = products.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0
                    ? "Available"
                    : "Out of Stock"
            });
            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Price: {item.Price}");
                Console.WriteLine($"Stock Status: {item.StockStatus}");
                Console.WriteLine("-------------------");
            }

            /*Q7*/

            spacing(7);

            List<string> showProducts = products.Select((x, y) => $"{y+1}-{x.ProductName}" ).ToList();
            foreach (var i in showProducts)
            {
                Console.WriteLine(i);
                
            }

            /*Q8*/

            spacing(8);
            List<Product> ProductByCatAndPrice=products.Select(x=>x).OrderBy(x=>x.Category).ThenByDescending(x=>x.UnitPrice).ToList();

            /*Q9*/
            spacing(9);
            List<Product> BeveragesOrderByPrice=products.Select(x=>x).Where(x=>x.ProductName== "Beverages")
                        .OrderByDescending(x=>x.UnitPrice).ToList();

            foreach(var x in  BeveragesOrderByPrice)
            {
                Console.WriteLine($"Name:{x.ProductName}-Stock:{x.UnitsInStock}");
            }

            /*Q10*/
            spacing(10);

            var QueryResult = from customer in customers
                              from order in customer.Orders
                              where order.OrderDate.Year >= 1997
                              select new{
                                        customer.CustomerID,
                                        order.OrderDate
                              };

            foreach (var item in QueryResult)
            {
                Console.WriteLine($"CustomerID: {item.CustomerID}, OrderDate: {item.OrderDate:d}");
            }

            /*Q11*/
            spacing(11);

            List<string> showIndexProducts = products.Select((x, y) => $"{y}-{x.ProductName}").ToList();
            foreach (var i in showIndexProducts)
            {
                Console.WriteLine(i);

            }

            /*Q12*/
            spacing(12);

            string[] Arr = {"aPPLE", "AbAcUs", "bRaNcH","BlUeBeRrY", "ClOvEr", "cHeRry"};

            var StringResult= Arr
                .OrderBy(x => x.Length)
                .ThenBy(x => x.ToLower());

            foreach (var word in StringResult)
            {
                Console.WriteLine(word);
            }

            /*Q13*/
            spacing(13);
            string[] Digits= { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

           
            var numbers = Digits
                .Where(x => x.ToString().Length > 1 && x.ToString()[1] == 'i')
                .Reverse()
                .ToList();

            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }




        }

        public static void spacing(int n)
        {
            Console.WriteLine($"==============Q{n}================");
        }
    }
}
