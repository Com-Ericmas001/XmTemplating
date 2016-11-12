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
        public static void EvaluateBooleanCondition(string condition, IDictionary<string, string> vars, string expectedResult)
        {
            Evalutate("<EVAL ", " />", condition, vars, expectedResult);
            Evalutate("<IF ", $">{true}<:ELSE:>{false}</IF>", condition, vars, expectedResult);
        }
        public static void EvaluateExpression(string expression, IDictionary<string, string> vars, string expectedResult)
        {
            Evalutate("<EVAL ", " />", expression, vars, expectedResult);
        }

        private static void Evalutate(string beforeCondition, string afterCondition, string condition, IDictionary<string, string> vars, string expectedResult)
        {
            //Arrange
            var templateStr = $"{beforeCondition}[{condition}]{afterCondition}";
            var template = XmTemplateDeserializer.Deserialize(templateStr);

            //Act
            var result = new XmTemplateSerializer(template, vars, new Dictionary<string, IEnumerable<string>>()).SerializeText();

            var sw = new StringWriter();
            sw.WriteLine();
            sw.WriteLine(templateStr);
            sw.Write(string.Join(Environment.NewLine, vars.Select(x => $"{x.Key} = {x.Value}")));

            //Assert
            Assert.AreEqual(expectedResult, result, sw.ToString());
        }
    }
}
