using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace TRPG_KATA_ROT13
{
    [TestClass]
    public class UnitTestROT13
    {
        [TestMethod]
        public void Input_a_should_get_n()
        {
            var rotTranslator = new RotTranslator();
            var result = rotTranslator.Tanslate("a");
            Assert.AreEqual("n", result);
        }

        [TestMethod]
        public void Input_b_should_get_o()
        {
            var rotTranslator = new RotTranslator();
            var result = rotTranslator.Tanslate("b");
            Assert.AreEqual("o", result);
        }

        [TestMethod]
        public void Input_ab_should_get_no()
        {
            var rotTranslator = new RotTranslator();
            var result = rotTranslator.Tanslate("ab");
            Assert.AreEqual("no", result);
        }

        [TestMethod]
        public void Input_Ab_should_get_No()
        {
            var rotTranslator = new RotTranslator();
            var result = rotTranslator.Tanslate("Ab");
            Assert.AreEqual("No", result);
        }

        [TestMethod]
        public void Input_A12b_should_get_N12o()
        {
            var rotTranslator = new RotTranslator();
            var result = rotTranslator.Tanslate("A12b");
            Assert.AreEqual("N12o", result);
        }

        [TestMethod]
        public void Input_A1_2b_should_get_N1_2o()
        {
            var rotTranslator = new RotTranslator();
            var result = rotTranslator.Tanslate("A1 2b");
            Assert.AreEqual("N1 2o", result);
        }

        [TestMethod]
        public void Input_case1()
        {
            var rotTranslator = new RotTranslator();
            var result = rotTranslator.Tanslate("EBG13 rknzcyr.");
            Assert.AreEqual("ROT13 example.", result);
        }
    }

    public class RotTranslator
    {
        private readonly int _rotRange = 13;

        public string Tanslate(string str)
        {
            var charArray = str.ToCharArray();
            var result = new StringBuilder();
            foreach (var ch in charArray)
            {
                if (!Rot13Case(ch))
                {
                    result.Append(ch);
                    continue;
                }
                var asciiNum = Convert.ToInt32(ch);
                if (ForwardCase(asciiNum))
                {
                    asciiNum += _rotRange;
                }
                else
                {
                    asciiNum -= _rotRange;
                }
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

        private static bool Rot13Case(char ch)
        {
            var asciiNum = Convert.ToInt32(ch);
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