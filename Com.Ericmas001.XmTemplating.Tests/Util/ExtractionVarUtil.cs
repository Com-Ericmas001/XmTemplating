using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Deserialization;
using Com.Ericmas001.XmTemplating.VariableExtraction;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util
{
    public static class ExtractionVarUtil
    {
        public static void TestExtraction(IEnumerable<string> templates, IEnumerable<ExtractedVariable> expectedVars)
        {
            //Arrange
            var eVars = expectedVars.ToArray();

            foreach (var template in templates)
            {
                //Act
                var result = VariableExtractor.ExtractVariables(XmTemplateDeserializer.Deserialize(template));

                //Assert
                Assert.AreEqual(eVars.Count(), result.Count, template);
                Assert.AreEqual(false, result.Keys.Except(eVars.Select(x => x.Name)).Any(), Environment.NewLine, template);

                foreach (var xVar in eVars)
                {
                    var desc = "VAR: " + xVar.Name + Environment.NewLine + template;
                    var v = result[xVar.Name];
                    Assert.AreEqual(xVar.Name, v.Name, desc);
                    Assert.AreEqual(xVar.GuessedType, v.GuessedType, desc);
                    Assert.AreEqual(xVar.IsArray, v.IsArray, desc);
                    Assert.AreEqual(xVar.Values.Count(), v.Values.Count(), desc);
                    Assert.AreEqual(false, xVar.Values.Except(v.Values).Any(), desc);
                }
            }
        }
        public static void TestExtraction(string template, IEnumerable<ExtractedVariable> expectedVars)
        {
            TestExtraction(new[] { template }, expectedVars);
        }
        public static void TestExtraction(string template, ExtractedVariable expectedVar)
        {
            TestExtraction(new[] { template }, new[] { expectedVar });
        }
        public static void TestExtraction(IEnumerable<string> templates, ExtractedVariable expectedVar)
        {
            TestExtraction(templates, new[] { expectedVar });
        }

    }
}
