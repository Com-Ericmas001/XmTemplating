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
            EvaluateUtil.EvaluateExpression("{V} + \"42\"", new Dictionary<string, string> {{"V", "21"}}, (42 + 21).ToString());
            EvaluateUtil.EvaluateExpression("\"42\" + {V}", new Dictionary<string, string> { { "V", "21" } }, (42 + 21).ToString());
            EvaluateUtil.EvaluateExpression("\"42\" + \"21\"", new Dictionary<string, string>(), (42 + 21).ToString());
            EvaluateUtil.EvaluateExpression("{V1} + {V2}", new Dictionary<string, string> { { "V1", "42" }, { "V2", "21" } }, (42 + 21).ToString());
        }
        [TestMethod]
        public void TestMinus()
        {
            EvaluateUtil.EvaluateExpression("{V} - \"42\"", new Dictionary<string, string> { { "V", "63" } }, (63 - 42).ToString());
            EvaluateUtil.EvaluateExpression("\"63\" - {V}", new Dictionary<string, string> { { "V", "42" } }, (63 - 42).ToString());
            EvaluateUtil.EvaluateExpression("\"63\" - \"42\"", new Dictionary<string, string>(), (63 - 42).ToString());
            EvaluateUtil.EvaluateExpression("{V1} - {V2}", new Dictionary<string, string> { { "V1", "63" }, { "V2", "42" } }, (63 - 42).ToString());
        }
        [TestMethod]
        public void TestMultiply()
        {
            EvaluateUtil.EvaluateExpression("{V} * \"7\"", new Dictionary<string, string> { { "V", "6" } }, (6 * 7).ToString());
            EvaluateUtil.EvaluateExpression("\"7\" * {V}", new Dictionary<string, string> { { "V", "6" } }, (6 * 7).ToString());
            EvaluateUtil.EvaluateExpression("\"6\" * \"7\"", new Dictionary<string, string>(), (6 * 7).ToString());
            EvaluateUtil.EvaluateExpression("{V1} * {V2}", new Dictionary<string, string> { { "V1", "6" }, { "V2", "7" } }, (6 * 7).ToString());
        }
        [TestMethod]
        public void TestDivide()
        {
            EvaluateUtil.EvaluateExpression("{V} / \"7\"", new Dictionary<string, string> { { "V", "42" } }, (42 / 7).ToString());
            EvaluateUtil.EvaluateExpression("\"42\" / {V}", new Dictionary<string, string> { { "V", "7" } }, (42 / 7).ToString());
            EvaluateUtil.EvaluateExpression("\"42\" / \"7\"", new Dictionary<string, string>(), (42 / 7).ToString());
            EvaluateUtil.EvaluateExpression("{V1} / {V2}", new Dictionary<string, string> { { "V1", "42" }, { "V2", "7" } }, (42 / 7).ToString());
        }
        [TestMethod]
        public void TestPriority()
        {
            EvaluateUtil.EvaluateExpression("\"3\" + \"3\" * \"2\"", new Dictionary<string, string>(), (3 + 3 * 2).ToString());
            EvaluateUtil.EvaluateExpression("\"3\" * \"3\" - \"2\"", new Dictionary<string, string>(), (3 * 3 - 2).ToString());
            EvaluateUtil.EvaluateExpression("\"3\" * \"3\" / \"2\"", new Dictionary<string, string>(), (3 * 3 / 2).ToString());
            EvaluateUtil.EvaluateExpression("\"1\" * \"1\" + \"1\" * \"1\"", new Dictionary<string, string>(), (1 * 1 + 1 * 1).ToString());
            EvaluateUtil.EvaluateExpression("\"1\" + \"1\" / \"1\" - \"1\"", new Dictionary<string, string>(), (1 + 1 / 1 - 1).ToString());
            EvaluateUtil.EvaluateExpression("\"3\" * \"3\" / \"2\" + \"2\"", new Dictionary<string, string>(), (3 * 3 / 2 + 2).ToString());

            EvaluateUtil.EvaluateExpression("(\"3\" + \"3\") * \"2\"", new Dictionary<string, string>(), ((3 + 3) * 2).ToString());
            EvaluateUtil.EvaluateExpression("\"3\" * (\"3\" - \"2\")", new Dictionary<string, string>(), (3 * (3 - 2)).ToString());
            EvaluateUtil.EvaluateExpression("\"3\" * (\"3\" / \"2\")", new Dictionary<string, string>(), (3 * (3 / 2)).ToString());
            EvaluateUtil.EvaluateExpression("\"1\" * (\"1\" + \"1\") * \"1\"", new Dictionary<string, string>(), (1 * (1 + 1) * 1).ToString());
            EvaluateUtil.EvaluateExpression("(\"1\" + \"1\") / (\"1\" - \"2\")", new Dictionary<string, string>(), ((1 + 1) / (1 - 2)).ToString());
            EvaluateUtil.EvaluateExpression("\"3\" * \"3\" / (\"2\" + \"2\")", new Dictionary<string, string>(), (3 * 3 / (2 + 2)).ToString());
        }
    }
}
