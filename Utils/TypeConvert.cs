using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class TypeConvert
    {
        /* public static string ToHex(int org)
         {
             string HexStr = Convert.ToString(org, 2);
             return HexStr.Length == 1 ? "0" + HexStr : HexStr;
         }*/

        public static string ToHex(string org)
        {
            int dec = Convert.ToInt32(org, 10);
            //string HexStr = dec.ToString("X");
            string HexStr = Convert.ToString(dec, 16).ToUpper();
            return HexStr.Length == 1 ? "0" + HexStr : HexStr; 
        }

        public static string DEC_to_HEX(int Dec)
        {
            string a;
            string DEC_to_HEX = "";

            while (Dec > 0)
            {
                a = (Dec % 16).ToString();
                switch (a)
                {
                    case "10": a = "A"; break;
                    case "11": a = "B"; break;
                    case "12": a = "C"; break;
                    case "13": a = "D"; break;
                    case "14": a = "E"; break;
                    case "15": a = "F"; break;
                }
                DEC_to_HEX = a + DEC_to_HEX;

                Dec = Dec / 16;
            }
            return DEC_to_HEX;
        }
    }
}
