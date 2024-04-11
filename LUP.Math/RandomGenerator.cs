using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Math
{
    public static class RandomGenerator
    {
        private static readonly Random random = new(DateTime.Now.Millisecond);
        private static readonly char[] defaultWhiteList = GenerateDefaultWhiteList();

        public static string GenerateString(int size)
        {
            return GenerateString(size, defaultWhiteList);
        }


        public static string GenerateString(int size, params char[] whitelist)
        {
            char[] chars = new char[size];

            for (int i = 0; i < size; i++)
            {
                int index = random.Next(0, whitelist.Length);
                chars[i] = whitelist[index];
            }

            return new string(chars);
        }


        private static char[] GenerateDefaultWhiteList()
        {
            IEnumerable<char> chars =
                Enumerable.Range('a', 'z' - 'a' + 1)
                .Concat(Enumerable.Range('A', 'Z' - 'A' + 1))
                .Concat(Enumerable.Range('0', '9' - '0' + 1))
                .Select(x => (char)x);

            return chars.ToArray();
        }
    }
}
