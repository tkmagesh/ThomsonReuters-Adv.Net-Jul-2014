﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace LearningLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new ProductsCollection();
            products.Add(new Product() { Id = 1, Name = "Pen", Cost = 20, Units = 90});
            products.Add(new Product() { Id = 7, Name = "Hen", Cost = 80, Units = 40 });
            products.Add(new Product() { Id = 4, Name = "Ten", Cost = 40, Units = 80 });
            products.Add(new Product() { Id = 8, Name = "Den", Cost = 60, Units = 30 });
            products.Add(new Product() { Id = 3, Name = "Len", Cost = 30, Units = 60 });
            products.Add(new Product() { Id = 9, Name = "Ken", Cost = 10, Units = 20 });

            Console.WriteLine("Initial List");
            for(var i=0;i<products.Count;i++)
                Console.WriteLine(products[i]);
            Console.WriteLine();

            Console.WriteLine("After sorting (default - by id)");
            products.Sort();
            for (var i = 0; i < products.Count; i++)
                Console.WriteLine(products[i]);
            Console.WriteLine();

            Console.WriteLine("After sorting by Cost");
            products.Sort(new ProductCompareByCost());
            for (var i = 0; i < products.Count; i++)
                Console.WriteLine(products[i]);
            Console.WriteLine( );

            Console.WriteLine("After sorting by Units - Using Delegates");
            //products.Sort(new CompareProductDelegate(Program.CompareProductByUnits));
            //products.Sort(CompareProductByUnits);

            /*products.Sort(delegate(Product p1, Product p2)
            {
                if (p1.Units > p2.Units) return 1;
                if (p1.Units < p2.Units) return -1;
                return 0;
            });*/

            //Lambda Expressions
           /* products.Sort((p1, p2) =>
            {
                if (p1.Units > p2.Units) return 1;
                if (p1.Units < p2.Units) return -1;
                return 0;
            });*/

            /*products.Sort((p1, p2) =>
            {
                return Math.Sign(p1.Units - p2.Units);
            });*/

            products.Sort((p1, p2) => Math.Sign(p1.Units - p2.Units));

            for (var i = 0; i < products.Count; i++)
                Console.WriteLine(products[i]);
            Console.WriteLine();

            Console.WriteLine("Sorting by name");
            products.Sort((p1, p2) => String.Compare(p1.Name, p2.Name, System.StringComparison.OrdinalIgnoreCase));

            for (var i = 0; i < products.Count; i++)
                Console.WriteLine(products[i]);
            Console.WriteLine();


            Console.ReadLine();
        }

        public static int CompareProductByUnits(Product p1, Product p2)
        {
            if (p1.Units > p2.Units) return 1;
            if (p1.Units < p2.Units) return -1;
            return 0;
        }
    }

    
}
