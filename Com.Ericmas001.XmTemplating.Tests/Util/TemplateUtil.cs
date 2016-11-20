using System.Collections.Generic;
using System.IO;
using Com.Ericmas001.XmTemplating.Deserialization;
using Com.Ericmas001.XmTemplating.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Ericmas001.XmTemplating.Tests.Util
{
    internal static class TemplateUtil
    {
        public static void EvaluateBooleanCondition(bool expectedResult, string condition, IDictionary<string, string> vars, IDictionary<string, IEnumerable<string>> arrays = null)
        {
            EvaluateExpression(expectedResult.ToString(), condition, vars, arrays);
            EvaluateIf(expectedResult, condition, vars, arrays);
        }
        public static void EvaluateIf(bool expectedResult, string condition, IDictionary<string, string> vars, IDictionary<string, IEnumerable<string>> arrays = null)
        {
            Evaluate(expectedResult.ToString(), "<IF ", $">{true}<:ELSE:>{false}</IF>", condition, vars, arrays);
        }
        public static void EvaluateExpression(string expectedResult, string expression, IDictionary<string, string> vars, IDictionary<string, IEnumerable<string>> arrays = null)
        {
            Evaluate(expectedResult, "<EVAL ", " />", expression, vars, arrays);
        }
        public static void EvaluateFor(string expectedResult, string condition, string content, IDictionary<string, string> vars, IDictionary<string, IEnumerable<string>> arrays = null)
        {
            Evaluate(expectedResult, "<FOR ", ">" + content + "</FOREACH>", condition, vars, arrays);
        }
        public static void EvaluateForeach(string expectedResult, string condition, string content, IDictionary<string, string> vars, IDictionary<string, IEnumerable<string>> arrays = null)
        {
            Evaluate(expectedResult, "<FOREACH ", ">" + content + "</FOREACH>", condition, vars, arrays);
        }
        public static void EvaluateDefine(string expected, string templateStr)
        {
            //Arrange
            var sw = new StringWriter();

            //Act
            var result = TemplateUtil.ExecuteTemplate(templateStr, sw);

            //Assert
            Assert.AreEqual(expected, result, sw.ToString());
        }

        public static void Evaluate(string expectedResult, string beforeCondition, string afterCondition, string condition, IDictionary<string, string> vars, IDictionary<string, IEnumerable<string>> arrays = null)
        {
            //Arrange
            var sw = new StringWriter();
            var templateStr = $"{beforeCondition}[{condition}]{afterCondition}";

            //Act
            var result = ExecuteTemplate(templateStr, sw, vars, arrays);
            
            //Assert
            Assert.AreEqual(expectedResult, result, sw.ToString());
        }


        public static string ExecuteTemplate(string templateStr, StringWriter sw, IDictionary<string, string> variables = null, IDictionary<string, IEnumerable<string>> arrays = null)
        {
            var template = XmTemplateDeserializer.Deserialize(templateStr);

            //Act
            var arr = arrays ?? new Dictionary<string, IEnumerable<string>>();
            var vars = variables ?? new Dictionary<string, string>();
            var result = XmTemplateSerializer.Serialize(template, vars, arr);

            sw.WriteLine();
            sw.WriteLine(templateStr);
            foreach (var x in vars)
                sw.WriteLine("{0} = {1}", x.Key, x.Value);
            foreach (var array in arr)
                sw.WriteLine("{0} = ({1})", array.Key, string.Join(", ", array.Value));
            return result;
        }
    }
}
