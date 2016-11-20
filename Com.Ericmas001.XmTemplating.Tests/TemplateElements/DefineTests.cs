using System;
using System.Linq;
using Com.Ericmas001.XmTemplating.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Ericmas001.XmTemplating.Tests.TemplateElements
{
    [TestClass]
    public class DefineTests
    {
        [TestMethod]
        public void TestDefine()
        {
            var expectedResult = "COOL!";

            TemplateUtil.EvaluateDefine(expectedResult, "<DEFINE {Var}>" + expectedResult + "</DEFINE>{Var}");

            //Redefine
            TemplateUtil.EvaluateDefine(expectedResult, "<DEFINE {Var}>NOT COOL</DEFINE><DEFINE {Var}>" + expectedResult + "</DEFINE>{Var}");

            //Redefine in subscope is ignored
            TemplateUtil.EvaluateDefine(expectedResult, "<DEFINE {Var}>" + expectedResult + "</DEFINE><IF [\"True\"]><DEFINE {Var}>NOT COOL</DEFINE></IF>{Var}");
            TemplateUtil.EvaluateDefine(expectedResult, "<DEFINE {Var}>" + expectedResult + "</DEFINE><FOR [{I} From \"1\" To \"5\"]><DEFINE {Var}>NOT COOL</DEFINE></FOR>{Var}");
            TemplateUtil.EvaluateDefine(expectedResult, "<DEFINE {Var}>" + expectedResult + "</DEFINE><FOREACH [{X} IN (\"A\",\"B\",\"C\")]><DEFINE {Var}>NOT COOL</DEFINE></FOREACH>{Var}");
        }
        [TestMethod]
        public void TestDefineArray()
        {
            var stuff = new[] { "A", "B", "C", "D", "E", "F" };
            var expectedResult = string.Concat(stuff);

            TemplateUtil.EvaluateDefine(expectedResult, "<DEFINE_ARRAY {Vars}>" + string.Join(Environment.NewLine, stuff) + "</DEFINE_ARRAY><FOREACH {Vars}>{Vars}</FOREACH>");
            TemplateUtil.EvaluateDefine(expectedResult, "<DEFINE_ARRAY {Vars}>" + Environment.NewLine + string.Join(Environment.NewLine, stuff) + Environment.NewLine + "</DEFINE_ARRAY><FOREACH {Vars}>{Vars}</FOREACH>");

            //Redefine
            TemplateUtil.EvaluateDefine(expectedResult, "<DEFINE_ARRAY {Vars}>" + string.Concat(stuff.Reverse()) + "</DEFINE_ARRAY><DEFINE_ARRAY {Vars}>" + string.Join(Environment.NewLine, stuff) + "</DEFINE_ARRAY><FOREACH {Vars}>{Vars}</FOREACH>");

            //Redefine in subscope is ignored
            TemplateUtil.EvaluateDefine(expectedResult, "<DEFINE_ARRAY {Vars}>" + string.Join(Environment.NewLine, stuff) + "</DEFINE_ARRAY><IF [\"True\"]><DEFINE_ARRAY {Vars}>" + string.Concat(stuff.Reverse()) + "</DEFINE_ARRAY></IF><FOREACH {Vars}>{Vars}</FOREACH>");
            TemplateUtil.EvaluateDefine(expectedResult, "<DEFINE_ARRAY {Vars}>" + string.Join(Environment.NewLine, stuff) + "</DEFINE_ARRAY><FOR [{I} From \"1\" To \"5\"]><DEFINE_ARRAY {Vars}>" + string.Concat(stuff.Reverse()) + "</DEFINE_ARRAY></FOR><FOREACH {Vars}>{Vars}</FOREACH>");
            TemplateUtil.EvaluateDefine(expectedResult, "<DEFINE_ARRAY {Vars}>" + string.Join(Environment.NewLine, stuff) + "</DEFINE_ARRAY><FOREACH [{X} IN (\"A\",\"B\",\"C\")]><DEFINE_ARRAY {Vars}>" + string.Concat(stuff.Reverse()) + "</DEFINE_ARRAY></FOREACH><FOREACH {Vars}>{Vars}</FOREACH>");
        }
    }
}
