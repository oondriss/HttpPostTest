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

            Parallel.ForEach(Enumerable.Range(0, 500), i =>
            {
                Task<TestResult> task = Task<TestResult>.Factory.StartNew(() => { return PostRequest.SendRequest(i); });
                results.Add(task.Result);
            });

            Console.WriteLine();
            Console.WriteLine();

            foreach (var item in results)
            {
                Console.WriteLine($"HTTP{item.HttpStatus}\t{item.Duration.TotalSeconds}s\t{item.Result.sentiment}-{item.Result.polarity}-{item.Result.subjectivity}");
            }

            Console.WriteLine();

            Console.WriteLine($"Number of non-HTTP200:{results.Where(i => i.HttpStatus != 200).Count()}");
            Console.WriteLine($"Number of HTTP200:{results.Where(i => i.HttpStatus == 200).Count()}");
            Console.WriteLine($"Average response time:{ TimeSpan.FromMilliseconds(results.Select(i => i.Duration.TotalMilliseconds).Average()).TotalSeconds}");
            Console.WriteLine($"Request data:{results.Last().Result.ToString()}");
            Console.ReadLine();

        }
    }
}