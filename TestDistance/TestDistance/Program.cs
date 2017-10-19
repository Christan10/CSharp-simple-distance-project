using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDistance
{
    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            var users = ReadInput("How many users do you have");
            var results = AddUserToList(users);
            AverMaxMin(results);
        }

        public static int ReadInput(string input)
        {
            Console.WriteLine(input);
            var userInput = Console.ReadLine();
            return int.TryParse(userInput, out int rInput) ? rInput : ReadInput(input);
        }

        public static double GetRandomNumber(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }

        public static double CalcDistance(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        public static List<User> AddUserToList(int n)
        {
            var totalUsers = new List<User>();
            for (var i = 1; i <= n; i++)
            {
                var x = GetRandomNumber(1, 100);
                var y = GetRandomNumber(1, 100);
                totalUsers.Add(new User() {Id = i, Xcoord = x, Ycoord = y, Distance = CalcDistance(x, y)});
            }
            return totalUsers;
        }

        public static void AverMaxMin(List<User> items)
        {
            var averDist = items.Average(x => x.Distance);
            Console.WriteLine($"average distance = {averDist}");
            var minimum = items.Min(x => x.Distance);
            var minimumItem = items.FirstOrDefault(x => x.Distance == minimum);
            Console.WriteLine($"minimum distance user {minimumItem?.Id} {minimum}");
            var maximum = items.Max(x => x.Distance);
            var maximumItem = items.FirstOrDefault(x => x.Distance == maximum);
            Console.WriteLine($"maximum distance user {maximumItem?.Id} {maximum}");
        }
    }
}
