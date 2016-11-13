using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Com.Ericmas001.XmTemplating.Deserialization;
using Com.Ericmas001.XmTemplating.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Ericmas001.XmTemplating.Tests.Util
{
    internal static class EvaluateUtil
    {
        public static void EvaluateBooleanCondition(bool expectedResult, string condition, IDictionary<string, string> vars, Dictionary<string, IEnumerable<string>> arrays = null)
        {
            EvaluateExpression(expectedResult.ToString(), condition, vars, arrays);
            EvaluateIf(expectedResult, condition, vars, arrays);
        }
        public static void EvaluateIf(bool expectedResult, string condition, IDictionary<string, string> vars, Dictionary<string, IEnumerable<string>> arrays = null)
        {
            Evaluate(expectedResult.ToString(), "<IF ", $">{true}<:ELSE:>{false}</IF>", condition, vars, arrays);
        }
        public static void EvaluateExpression(string expectedResult, string expression, IDictionary<string, string> vars, Dictionary<string, IEnumerable<string>> arrays = null)
        {
            Evaluate(expectedResult, "<EVAL ", " />", expression, vars, arrays);
        }
        public static void EvaluateFor(string expectedResult, string condition, string content, IDictionary<string, string> vars, Dictionary<string, IEnumerable<string>> arrays = null)
        {
            Evaluate(expectedResult, "<FOR ", ">" + content + "</FOREACH>", condition, vars, arrays);
        }
        public static void EvaluateForeach(string expectedResult, string condition, string content, IDictionary<string, string> vars, Dictionary<string, IEnumerable<string>> arrays = null)
        {
            Evaluate(expectedResult, "<FOREACH ", ">" + content + "</FOREACH>", condition, vars, arrays);
        }

        public static void Evaluate(string expectedResult, string beforeCondition, string afterCondition, string condition, IDictionary<string, string> vars, Dictionary<string, IEnumerable<string>> arrays = null)
        {
            //Arrange
            var templateStr = $"{beforeCondition}[{condition}]{afterCondition}";
            var template = XmTemplateDeserializer.Deserialize(templateStr);

            //Act
            var arr = arrays ?? new Dictionary<string, IEnumerable<string>>();
            var result = new XmTemplateSerializer(template, vars, arr).SerializeText();

            var sw = new StringWriter();
            sw.WriteLine();
            sw.WriteLine(templateStr);
            sw.WriteLine(string.Join(Environment.NewLine, vars.Select(x => $"{x.Key} = {x.Value}")));
            foreach (var array in arr)
            {
                sw.WriteLine("{0} = ({1})", array.Key, string.Join(", ", array.Value));
            }

            //Assert
            Assert.AreEqual(expectedResult, result, sw.ToString());
        }
    }
}
