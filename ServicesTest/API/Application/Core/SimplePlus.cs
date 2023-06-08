using System.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Application.Core
{
    public class SimplePlus
    {
        public SimplePlus()
        {
            
        }
        public static bool ValidateSumFormat(string q)
        {
            string[] parts = q.Replace(" ", "").Replace("=","").Replace("?","").Split('+');

            if (parts.Length < 2)
                return false;

            foreach (string part in parts)
            {
                if (!int.TryParse(part, out _))
                    return false;
            }

            return true;
        }

        public static string GenerateSimplePlus(string q)
        {
            string[] parts = q.Replace(" ", "").Replace("=","").Replace("?","").Split('+');
            int sum = 0;

            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    sum += number;
                }
            }
            return sum.ToString();
        }
    }
}