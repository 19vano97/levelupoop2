using _20241109_HW_Linq101;

internal class Program
{
    private static void Main(string[] args)
    {
        #region intarr

            int[] array = [5, 4, 2, 100, -56, 45, 234, 123, 4254, 42, -4, 0, -1, 1, 34, 7];
    
            var intArrRangeQuery = from n in array
                                   where n < 10 && n > -2
                                   orderby n descending
                                   select n;
                
            var intArrRangeMethod = array.Where(n => n > -2 && n < 10)
                                         .OrderByDescending(n => n);
            
            // Print(intArrRangeQuery, "Int Array Query");
            // Print(intArrRangeQuery, "Int Array Method");

            // int i = 0;
            // var intNumInPlaceQuery = from ar in array
            //                          where ar == i
            //                          select (ar, i);

            var intNumInPlaceMethod = array.Select((num, index) => (Num: num, InPlace: num == index));

            #region cw

                // foreach (var item in intNumInPlaceQuery)
                // {
                //     System.Console.WriteLine($"{item.ar}, {item.i}");
                // }
    
                foreach (var item in intNumInPlaceMethod)
                {
                    System.Console.WriteLine($"{item.Num}, {item.InPlace}");
                }
                
            #endregion

            var intArrReverseQuery = (from n in array
                                      where n < 0
                                      orderby n
                                      select n)
                                     .Reverse();

            var intArrReverseMethod = array.Where(n => n < 0)
                                           .OrderBy(n => n)
                                           .Select(n => n)
                                           .Reverse();

            // foreach (var item in intArrReverseMethod)
            // {
            //     System.Console.WriteLine(item);
            // }


        #endregion

        #region products

            List<Product> products = Products.ProductList;
    
            var productsValueQuery = from p in products
                                     where p.UnitsInStock > 0
                                     select (Pn: p.ProductName, Cat: p.Category);
    
            var productsValueMethod = products.Where(p => p.UnitsInStock > 0).Select(p => p.ProductName);
            
            // Print(productsValueQuery, "Product Value Query");
            // Print(productsValueMethod, "Product Value Method");
            
        #endregion

        #region customers

            List<Customer> customers = Customers.CustomerList;
    
            var custMexicoQuery = from cust in customers
                                  where cust.Country == "Mexico"
                                  select cust;
    
            var custMexicoMethod = customers.Where(c => c.Country == "Mexico");
    
            #region cw

                // foreach (var cust in custMexicoQuery)
                // {
                //     System.Console.WriteLine($"{cust.CustomerID}, {cust.City}");
        
                //     foreach (var item in cust.Orders)
                //     {
                //         System.Console.WriteLine($"{item.OrderID}, {item.OrderDate}");
                //     }
                // }
        
                // System.Console.WriteLine();
        
                // foreach (var cust in custMexicoMethod)
                // {
                //     System.Console.WriteLine($"{cust.CustomerID}, {cust.City}");
        
                //     foreach (var item in cust.Orders)
                //     {
                //         System.Console.WriteLine($"{item.OrderID}, {item.OrderDate}");
                //     }
                // }
                
            #endregion

            var custOrderLowPriceQuery = (from cust in customers
                                         from order in cust.Orders
                                         where order.Total < 100 && order.OrderDate <= new DateTime(1997, 11, 19)
                                         orderby order.OrderDate descending
                                         select (cust.CustomerID, order.OrderID, order.Total, order.OrderDate))
                                         .Take(3);

            var custOrderLowPriceMethod = customers.SelectMany(c => c.Orders, (c, order) => new {c, order})
                                                   .Where(c => c.order.Total < 100 && c.order.OrderDate < new DateTime(1997, 11, 19))
                                                   .OrderByDescending(od => od.order.OrderDate)
                                                   .Select(c => (c.c.CustomerID, c.order.OrderID, c.order.Total, c.order.OrderDate))
                                                   .Take(3);

            #region cw

                // foreach (var item in custOrderLowPriceQuery)
                // {
                //     System.Console.WriteLine($"{item.CustomerID} {item.OrderID} {item.Total} {item.OrderDate}");
                // }
    
                // foreach (var item in custOrderLowPriceMethod)
                // {
                //     System.Console.WriteLine($"{item.CustomerID} {item.OrderID} {item.Total} {item.OrderDate}");
                // }
                 
            #endregion

        #endregion

        string[] categories = {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };

        var q = from c in categories
                join p in products on c equals p.Category into ps
                from p in ps
                select (Category: c, p.ProductName);

        // var q1 = products.Join(categories, p => p.Category, c => c, res => new {category = res.Category, productName = res.ProductName});
        
        var q2 = products.Join(categories, p => p.Category, c => c, (p, category) => new {category = category, productName = p.ProductName});

        // foreach (var v in q2)
        // {
        //     Console.WriteLine(v.category + ": " + v.productName);
        // }
    }

    public static void Print(dynamic toPrint, string message = null)
    {
        System.Console.WriteLine($"Type: {message}");
        foreach (var item in toPrint)
        {
            System.Console.WriteLine(item);
        }

        System.Console.WriteLine();
    }
}