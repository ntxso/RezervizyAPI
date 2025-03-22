using System;
using System.Collections.Generic;
using System.Text;

namespace CoreNT.Utilities
{
    public class CreateRandom
    {
        public static string Random6Number()
        {
            string result = "";
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                result += (char)(rnd.Next(10) + 48);
            }
            return result;
        }
    }
}
