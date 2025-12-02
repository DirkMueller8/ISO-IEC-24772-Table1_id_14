using System;

namespace Table1_id_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demonstrating rule 24772: prohibit dependence on side effects within an expression.");
            Bad();
            Good();
        }

        static void Bad()
        {
            Console.WriteLine("\nBad example:");

            int i = 1;
            // Side effect (assignment to i) occurs inside the expression and the expression result depends on it.
            // This is hard to read and error-prone.
            int result = i + (i = 10);
            Console.WriteLine($"After expression: i = {i}, result = {result}");

            int index = 0;
            int[] arr = new[] { 100, 200 };
            // The sum depends on the side effect of index++ inside the same expression.
            int sum = arr[index++] + arr[index];
            Console.WriteLine($"After expression: index = {index}, sum = {sum}");
        }

        static void Good()
        {
            Console.WriteLine("\nGood example:");

            int i = 1;
            // Separate the read and the write so the expression no longer depends on an internal side effect.
            int left = i;
            i = 10; // isolate side effect
            int result = left + i;
            Console.WriteLine($"After statements: i = {i}, result = {result}");

            int index = 0;
            int[] arr = new[] { 100, 200 };
            // Read, then perform the mutation, then use the values — order is explicit and clear.
            int first = arr[index];
            index++;
            int second = arr[index];
            int sum = first + second;
            Console.WriteLine($"After statements: index = {index}, sum = {sum}");
        }
    }
}