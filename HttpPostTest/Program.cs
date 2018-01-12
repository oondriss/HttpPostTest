using HttpPostTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpPostTest
{
    class Program
    {
        public static List<TestResult> results = new List<TestResult>();

        static void Main(string[] args)
        {

            Parallel.ForEach(Enumerable.Range(0, 1), i =>
            {
                Task<TestResult> task = Task<TestResult>.Factory.StartNew(() => { return PostRequest.SendRequest(i); });
                results.Add(task.Result);
            });

            Console.WriteLine();
            Console.WriteLine();

            foreach (var item in results)
            {
                Console.WriteLine($"HTTP{item.HttpStatus}\t\t{item.Duration.TotalSeconds}s");
            }
            Console.ReadLine();
            //var tr = PostRequest.SendRequest();
        }
    }
}