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

           
        }
    }
}
