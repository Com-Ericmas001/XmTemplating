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

        private static void Evaluate(string expectedResult, string beforeCondition, string afterCondition, string condition, IDictionary<string, string> vars, Dictionary<string, IEnumerable<string>> arrays = null)
        {
            //Arrange
            var templateStr = $"{beforeCondition}[{condition}]{afterCondition}";
            var template = XmTemplateDeserializer.Deserialize(templateStr);

            //Act
            var result = new XmTemplateSerializer(template, vars, arrays ?? new Dictionary<string, IEnumerable<string>>()).SerializeText();

            var sw = new StringWriter();
            sw.WriteLine();
            sw.WriteLine(templateStr);
            sw.Write(string.Join(Environment.NewLine, vars.Select(x => $"{x.Key} = {x.Value}")));

            //Assert
            Assert.AreEqual(expectedResult, result, sw.ToString());
        }
    }
}
