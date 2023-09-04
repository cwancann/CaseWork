using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace.Controllers
{
    public class FibonacciController : Controller
    {
        // GET: Fibonacci/Index
        public ActionResult Index()
        {
            return View();
        }

        // POST: Fibonacci/Generate
        [HttpPost]
        public ActionResult Generate(int number)
        {
            if (number <= 0)
            {
                ViewBag.Error = "Please enter a positive number.";
                return View("Index");
            }

            // Generate the Fibonacci series using LINQ
            List<int> fibonacciSeries = Enumerable.Range(0, number)
                .Select(n => Fibonacci(n))
                .ToList();

            // Separate the result into even and odd numbers
            List<int> evenNumbers = fibonacciSeries.Where(x => x % 2 == 0).ToList();
            List<int> oddNumbers = fibonacciSeries.Where(x => x % 2 != 0).ToList();

            ViewBag.EvenNumbers = evenNumbers;
            ViewBag.OddNumbers = oddNumbers;

            return View("Index");
        }

        // Helper method to calculate Fibonacci number at a given position
        private int Fibonacci(int n)
        {
            if (n <= 0)
                return 0;
            if (n == 1)
                return 1;

            int a = 0, b = 1, temp = 0;

            for (int i = 2; i <= n; i++)
            {
                temp = a + b;
                a = b;
                b = temp;
            }

            return b;
        }
    }
}
