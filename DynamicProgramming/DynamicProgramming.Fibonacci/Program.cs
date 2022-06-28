using System;

namespace DynamicProgramming.Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
           long result = Fibonacci.Fib(50);
            Console.WriteLine(result);
        }
    }

    class Fibonacci
    {
        private static IDictionary<int, long> memo = new Dictionary<int, long>();

        public static long Fib(int n)
        {
            if (memo.ContainsKey(n)) return memo[n];
            if (n <= 2) return 1;
            memo[n] = Fib(n - 1) + Fib(n - 2);
            return memo[n];
        }
    }
}