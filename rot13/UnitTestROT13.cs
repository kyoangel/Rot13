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
            var result = rotTranslator.tanslate("a");
            Assert.AreEqual("n", result);
        }

        [TestMethod]
        public void Input_b_should_get_o()
        {
            var rotTranslator = new RotTranslator();
            var result = rotTranslator.tanslate("b");
            Assert.AreEqual("o", result);
        }

        [TestMethod]
        public void Input_ab_should_get_no()
        {
            var rotTranslator = new RotTranslator();
            var result = rotTranslator.tanslate("ab");
            Assert.AreEqual("no", result);
        }

        [TestMethod]
        public void Input_Ab_should_get_No()
        {
            var rotTranslator = new RotTranslator();
            var result = rotTranslator.tanslate("Ab");
            Assert.AreEqual("No", result);
        }

        [TestMethod]
        public void Input_A12b_should_get_N12o()
        {
            var rotTranslator = new RotTranslator();
            var result = rotTranslator.tanslate("A12b");
            Assert.AreEqual("N12o", result);
        }
    }

    public class RotTranslator
    {
        public string tanslate(string str)
        {
            var charArray = str.ToCharArray();
            var result = new StringBuilder();
            foreach (var ch in charArray)
            {
                if (Char.IsDigit(ch))
                {
                    result.Append(ch);
                    continue;
                }
                var asciiNum = Convert.ToInt32(ch);
                asciiNum += 13;
                result.Append(Convert.ToChar(asciiNum));
            }

            return result.ToString();

            if (str.Equals("a"))
            {
                return "n";
            }
            else
            {
                return "o";
            }
        }
    }
}