using System;

namespace BloomFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Bloom bloom = new Bloom();
            string data = "Hello Bloom Filter";
            bloom.AddData(data);
            Console.WriteLine($"Added '{data}'");

            //MessageBox.Show(bloom.LookUp(data).ToString());
            Console.WriteLine($"Looking up '{data}'");
            Console.WriteLine(bloom.LookUp(data).ToString());

            var hello = "Hello, World!";
            Console.WriteLine($"Looking up '{hello}'");
            Console.WriteLine(bloom.LookUp(hello).ToString());
        }
    }
}