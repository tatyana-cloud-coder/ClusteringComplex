using ClusteringComplex.MVC.Models;
using System;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = Coder.HashPassword("123456");
            Console.WriteLine(code);

            bool IsTrue = Coder.VerifyHashedPassword(code, "123456");
            Console.WriteLine(IsTrue);
        }
    }
}
