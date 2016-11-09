using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Com.Ericmas001.XmTemplating.Deserialization;
using Com.Ericmas001.XmTemplating.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Ericmas001.XmTemplating.Tests
{
    [TestClass]
    public class SingleOperatorsTests
    {
        private void Evaluate(string condition, IDictionary<string, string> vars, string expectedResult)
        {
            var arrays = new Dictionary<string, IEnumerable<string>>();

            //Arrange
            var templateStrEval = $"<EVAL [{condition}] />";
            var templateEval = XmTemplateDeserializer.Deserialize(templateStrEval);

            //Act
            var resultEval = new XmTemplateSerializer(templateEval, vars, arrays).SerializeText();

            StringWriter sw = new StringWriter();
            sw.WriteLine();
            sw.WriteLine(templateStrEval);
            sw.Write(string.Join(Environment.NewLine, vars.Select(x => $"{x.Key} = {x.Value}")));

            //Assert
            Assert.AreEqual(expectedResult, resultEval, sw.ToString());

            //Arrange
            var templateStrIf = $"<IF [{condition}]>{true}<:ELSE:>{false}</IF>";
            var templateIf = XmTemplateDeserializer.Deserialize(templateStrIf);
            var resultIf = new XmTemplateSerializer(templateIf, vars, arrays).SerializeText();
            sw = new StringWriter();
            sw.WriteLine();
            sw.WriteLine(templateStrIf);
            sw.Write(string.Join(Environment.NewLine, vars.Select(x => $"{x.Key} = {x.Value}")));

            //Assert
            Assert.AreEqual(expectedResult, resultIf, sw.ToString());
        }
        [TestMethod]
        public void TestEqualSuccess()
        {
            Evaluate("{V} = \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
            Evaluate("{V} == \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
            Evaluate("{V} EQ \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
        }
        [TestMethod]
        public void TestEqualFails()
        {
            Evaluate("{V} = \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
            Evaluate("{V} == \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
            Evaluate("{V} EQ \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
        }
        [TestMethod]
        public void TestNotEqualSuccess()
        {
            Evaluate("{V} != \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
            Evaluate("{V} <> \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
            Evaluate("{V} NQ \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
            Evaluate("{V} NE \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
        }
        [TestMethod]
        public void TestNotEqualFails()
        {
            Evaluate("{V} != \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
            Evaluate("{V} <> \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
            Evaluate("{V} NQ \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
            Evaluate("{V} NE \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
        }

        [TestMethod]
        public void TestLowerThanSuccess()
        {
            Evaluate("{V} < \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
            Evaluate("{V} LT \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
        }
        [TestMethod]
        public void TestLowerThanFailsBecauseEqual()
        {
            Evaluate("{V} < \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
            Evaluate("{V} LT \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
        }
        [TestMethod]
        public void TestLowerThanFailsBecauseGreater()
        {
            Evaluate("{V} < \"42\"", new Dictionary<string, string> { { "V", "84" } }, false.ToString());
            Evaluate("{V} LT \"42\"", new Dictionary<string, string> { { "V", "84" } }, false.ToString());
        }

        [TestMethod]
        public void TestLowerEqualSuccessBecauseLower()
        {
            Evaluate("{V} <= \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
            Evaluate("{V} LE \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
        }
        [TestMethod]
        public void TestLowerEqualSuccessBecauseEqual()
        {
            Evaluate("{V} <= \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
            Evaluate("{V} LE \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
        }
        [TestMethod]
        public void TestLowerEqualFailsBecauseGreater()
        {
            Evaluate("{V} <= \"42\"", new Dictionary<string, string> { { "V", "84" } }, false.ToString());
            Evaluate("{V} LE \"42\"", new Dictionary<string, string> { { "V", "84" } }, false.ToString());
        }

        [TestMethod]
        public void TestGreaterEqualSuccessBecauseGreater()
        {
            Evaluate("{V} >= \"42\"", new Dictionary<string, string> { { "V", "84" } }, true.ToString());
            Evaluate("{V} GE \"42\"", new Dictionary<string, string> { { "V", "84" } }, true.ToString());
        }
        [TestMethod]
        public void TestGreaterEqualSuccessBecauseEqual()
        {
            Evaluate("{V} >= \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
            Evaluate("{V} GE \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
        }
        [TestMethod]
        public void TestGreaterEqualFailsBecauseLower()
        {
            Evaluate("{V} >= \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
            Evaluate("{V} GE \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
        }

        [TestMethod]
        public void TestGreaterThanSuccessBecauseGreater()
        {
            Evaluate("{V} > \"42\"", new Dictionary<string, string> { { "V", "84" } }, true.ToString());
            Evaluate("{V} GT \"42\"", new Dictionary<string, string> { { "V", "84" } }, true.ToString());
        }
        [TestMethod]
        public void TestGreaterThanFailsBecauseEqual()
        {
            Evaluate("{V} > \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
            Evaluate("{V} GT \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
        }
        [TestMethod]
        public void TestGreaterThanFailsBecauseLower()
        {
            Evaluate("{V} > \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
            Evaluate("{V} GT \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
        }
        [TestMethod]
        public void TestAndSuccessBecauseBothTrue()
        {
            Evaluate("{V} = \"True\" AND \"True\" = \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());
            Evaluate("{V} = \"True\" && \"True\" = \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());

            Evaluate("{V} AND \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());
            Evaluate("{V} && \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());

        }
        [TestMethod]
        public void TestAndFailsBecauseOnlyOneTrue()
        {
            Evaluate("{V} = \"True\" AND \"True\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
            Evaluate("{V} = \"True\" && \"True\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());

            Evaluate("{V} AND \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
            Evaluate("{V} && \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());

        }
        [TestMethod]
        public void TestAndFailsBecauseBothFalse()
        {
            Evaluate("{V} = \"True\" AND \"False\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
            Evaluate("{V} = \"True\" && \"False\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());

            Evaluate("{V} AND \"False\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
            Evaluate("{V} && \"False\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());

        }
        [TestMethod]
        public void TestOrSuccessBecauseBothTrue()
        {
            Evaluate("{V} = \"True\" OR \"True\" = \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());
            Evaluate("{V} = \"True\" || \"True\" = \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());

            Evaluate("{V} OR \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());
            Evaluate("{V} || \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());

        }
        [TestMethod]
        public void TestOrSuccessBecauseOnlyOneTrue()
        {
            Evaluate("{V} = \"True\" OR \"True\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, true.ToString());
            Evaluate("{V} = \"True\" || \"True\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, true.ToString());

            Evaluate("{V} OR \"True\"", new Dictionary<string, string> { { "V", "False" } }, true.ToString());
            Evaluate("{V} || \"True\"", new Dictionary<string, string> { { "V", "False" } }, true.ToString());

        }
        [TestMethod]
        public void TestOrFailsBecauseBothFalse()
        {
            Evaluate("{V} = \"True\" OR \"False\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
            Evaluate("{V} = \"True\" || \"False\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());

            Evaluate("{V} OR \"False\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
            Evaluate("{V} || \"False\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());

        }
        [TestMethod]
        public void TestTrue()
        {
            Evaluate("{V}", new Dictionary<string, string> { { "V", "True" } }, true.ToString());
        }
        [TestMethod]
        public void TestFalse()
        {
            Evaluate("{V}", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
        }
    }
}
