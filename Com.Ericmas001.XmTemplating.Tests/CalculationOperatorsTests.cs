using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Ericmas001.XmTemplating.Tests
{
    [TestClass]
    public class CalculationOperatorsTests
    {
        [TestMethod]
        public void TestPlus()
        {
            EvaluateUtil.EvaluateExpression((42 + 21).ToString(), "{V} + \"42\"", new Dictionary<string, string> {{"V", "21"}});
            EvaluateUtil.EvaluateExpression((42 + 21).ToString(), "\"42\" + {V}", new Dictionary<string, string> { { "V", "21" } });
            EvaluateUtil.EvaluateExpression((42 + 21).ToString(), "\"42\" + \"21\"", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression((42 + 21).ToString(), "{V1} + {V2}", new Dictionary<string, string> { { "V1", "42" }, { "V2", "21" } });
        }
        [TestMethod]
        public void TestMinus()
        {
            EvaluateUtil.EvaluateExpression((63 - 42).ToString(), "{V} - \"42\"", new Dictionary<string, string> { { "V", "63" } });
            EvaluateUtil.EvaluateExpression((63 - 42).ToString(), "\"63\" - {V}", new Dictionary<string, string> { { "V", "42" } });
            EvaluateUtil.EvaluateExpression((63 - 42).ToString(), "\"63\" - \"42\"", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression((63 - 42).ToString(), "{V1} - {V2}", new Dictionary<string, string> { { "V1", "63" }, { "V2", "42" } });
        }
        [TestMethod]
        public void TestMultiply()
        {
            EvaluateUtil.EvaluateExpression((6 * 7).ToString(), "{V} * \"7\"", new Dictionary<string, string> { { "V", "6" } });
            EvaluateUtil.EvaluateExpression((6 * 7).ToString(), "\"7\" * {V}", new Dictionary<string, string> { { "V", "6" } });
            EvaluateUtil.EvaluateExpression((6 * 7).ToString(), "\"6\" * \"7\"", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression((6 * 7).ToString(), "{V1} * {V2}", new Dictionary<string, string> { { "V1", "6" }, { "V2", "7" } });
        }
        [TestMethod]
        public void TestDivide()
        {
            EvaluateUtil.EvaluateExpression((42 / 7).ToString(), "{V} / \"7\"", new Dictionary<string, string> { { "V", "42" } });
            EvaluateUtil.EvaluateExpression((42 / 7).ToString(), "\"42\" / {V}", new Dictionary<string, string> { { "V", "7" } });
            EvaluateUtil.EvaluateExpression((42 / 7).ToString(), "\"42\" / \"7\"", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression((42 / 7).ToString(), "{V1} / {V2}", new Dictionary<string, string> { { "V1", "42" }, { "V2", "7" } });
        }
        [TestMethod]
        public void TestPriority()
        {
            EvaluateUtil.EvaluateExpression((3 + 3 * 2).ToString(), "\"3\" + \"3\" * \"2\"", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression((3 * 3 - 2).ToString(), "\"3\" * \"3\" - \"2\"", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression((3 * 3 / 2).ToString(), "\"3\" * \"3\" / \"2\"", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression((1 * 1 + 1 * 1).ToString(), "\"1\" * \"1\" + \"1\" * \"1\"", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression((1 + 1 / 1 - 1).ToString(), "\"1\" + \"1\" / \"1\" - \"1\"", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression((3 * 3 / 2 + 2).ToString(), "\"3\" * \"3\" / \"2\" + \"2\"", new Dictionary<string, string>());

            EvaluateUtil.EvaluateExpression(((3 + 3) * 2).ToString(), "(\"3\" + \"3\") * \"2\"", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression((3 * (3 - 2)).ToString(), "\"3\" * (\"3\" - \"2\")", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression((3 * (3 / 2)).ToString(), "\"3\" * (\"3\" / \"2\")", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression((1 * (1 + 1) * 1).ToString(), "\"1\" * (\"1\" + \"1\") * \"1\"", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression(((1 + 1) / (1 - 2)).ToString(), "(\"1\" + \"1\") / (\"1\" - \"2\")", new Dictionary<string, string>());
            EvaluateUtil.EvaluateExpression((3 * 3 / (2 + 2)).ToString(), "\"3\" * \"3\" / (\"2\" + \"2\")", new Dictionary<string, string>());
        }
    }
}
