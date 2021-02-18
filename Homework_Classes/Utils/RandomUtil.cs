using System;

namespace ConsoleApp1.Utils
{
    public static class RandomUtil
    {
        private static readonly Random _random = new Random();

        public static int GetRandomInt(int min = 1, int max = 20)
        {
            return _random.Next(min, max);
        }
    }
}