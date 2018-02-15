using System;
using System.Text;

namespace TRPG_KATA_ROT13
{
    public class RotTranslator
    {
        private readonly int _rotRange = 13;

        public string Tanslate(string str)
        {
            var charArray = str.ToCharArray();
            var result = new StringBuilder();
            foreach (var ch in charArray)
            {
                var asciiNum = Convert.ToInt32(ch);
                if (!Rot13Case(asciiNum))
                {
                    result.Append(ch);
                    continue;
                }
                if (ForwardCase(asciiNum))
                    asciiNum += _rotRange;
                else
                    asciiNum -= _rotRange;
                result.Append(Convert.ToChar(asciiNum));
            }

            return result.ToString();
        }

        private bool ForwardCase(int asciiNum)
        {
            if (asciiNum >= 65 && asciiNum < 78)
            {
                return true;
            }

            if (asciiNum >= 97 && asciiNum < 110)
            {
                return true;
            }

            return false;
        }

        private static bool Rot13Case(int asciiNum)
        {
            if (asciiNum >= 65 && asciiNum <= 90)
            {
                return true;
            }

            if (asciiNum >= 97 && asciiNum <= 122)
            {
                return true;
            }

            return false;
        }
    }
}