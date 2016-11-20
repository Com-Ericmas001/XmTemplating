using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Ericmas001.XmTemplating.Tests.TemplateElements
{
    [TestClass]
    public class CalculationOperatorsTests
    {
        [TestMethod]
        public void TestPlus()
        {
            TemplateUtil.EvaluateExpression((42 + 21).ToString(), "{V} + \"42\"", new Dictionary<string, string> {{"V", "21"}});
            TemplateUtil.EvaluateExpression((42 + 21).ToString(), "\"42\" + {V}", new Dictionary<string, string> { { "V", "21" } });
            TemplateUtil.EvaluateExpression((42 + 21).ToString(), "\"42\" + \"21\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression((42 + 21).ToString(), "{V1} + {V2}", new Dictionary<string, string> { { "V1", "42" }, { "V2", "21" } });
        }
        [TestMethod]
        public void TestMinus()
        {
            TemplateUtil.EvaluateExpression((63 - 42).ToString(), "{V} - \"42\"", new Dictionary<string, string> { { "V", "63" } });
            TemplateUtil.EvaluateExpression((63 - 42).ToString(), "\"63\" - {V}", new Dictionary<string, string> { { "V", "42" } });
            TemplateUtil.EvaluateExpression((63 - 42).ToString(), "\"63\" - \"42\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression((63 - 42).ToString(), "{V1} - {V2}", new Dictionary<string, string> { { "V1", "63" }, { "V2", "42" } });
        }
        [TestMethod]
        public void TestMultiply()
        {
            TemplateUtil.EvaluateExpression((6 * 7).ToString(), "{V} * \"7\"", new Dictionary<string, string> { { "V", "6" } });
            TemplateUtil.EvaluateExpression((6 * 7).ToString(), "\"7\" * {V}", new Dictionary<string, string> { { "V", "6" } });
            TemplateUtil.EvaluateExpression((6 * 7).ToString(), "\"6\" * \"7\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression((6 * 7).ToString(), "{V1} * {V2}", new Dictionary<string, string> { { "V1", "6" }, { "V2", "7" } });
        }
        [TestMethod]
        public void TestDivide()
        {
            TemplateUtil.EvaluateExpression((42 / 7).ToString(), "{V} / \"7\"", new Dictionary<string, string> { { "V", "42" } });
            TemplateUtil.EvaluateExpression((42 / 7).ToString(), "\"42\" / {V}", new Dictionary<string, string> { { "V", "7" } });
            TemplateUtil.EvaluateExpression((42 / 7).ToString(), "\"42\" / \"7\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression((42 / 7).ToString(), "{V1} / {V2}", new Dictionary<string, string> { { "V1", "42" }, { "V2", "7" } });
        }
        [TestMethod]
        public void TestPriority()
        {
            TemplateUtil.EvaluateExpression((3 + 3 * 2).ToString(), "\"3\" + \"3\" * \"2\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression((3 * 3 - 2).ToString(), "\"3\" * \"3\" - \"2\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression((3 * 3 / 2).ToString(), "\"3\" * \"3\" / \"2\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression((1 * 1 + 1 * 1).ToString(), "\"1\" * \"1\" + \"1\" * \"1\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression((1 + 1 / 1 - 1).ToString(), "\"1\" + \"1\" / \"1\" - \"1\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression((3 * 3 / 2 + 2).ToString(), "\"3\" * \"3\" / \"2\" + \"2\"", new Dictionary<string, string>());

            TemplateUtil.EvaluateExpression(((3 + 3) * 2).ToString(), "(\"3\" + \"3\") * \"2\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression((3 * (3 - 2)).ToString(), "\"3\" * (\"3\" - \"2\")", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression((3 * (3 / 2)).ToString(), "\"3\" * (\"3\" / \"2\")", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression((1 * (1 + 1) * 1).ToString(), "\"1\" * (\"1\" + \"1\") * \"1\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression(((1 + 1) / (1 - 2)).ToString(), "(\"1\" + \"1\") / (\"1\" - \"2\")", new Dictionary<string, string>());
            TemplateUtil.EvaluateExpression((3 * 3 / (2 + 2)).ToString(), "\"3\" * \"3\" / (\"2\" + \"2\")", new Dictionary<string, string>());
        }
    }
}
