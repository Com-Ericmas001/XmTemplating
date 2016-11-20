using System;
using System.IO;
using System.Linq;
using Com.Ericmas001.XmTemplating.Deserialization;
using Com.Ericmas001.XmTemplating.Enums;
using Com.Ericmas001.XmTemplating.Tests.Util;
using Com.Ericmas001.XmTemplating.VariableExtraction;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Ericmas001.XmTemplating.Tests.VariableExtraction
{
    [TestClass]
    public class ExtractiomTests
    {
        [TestMethod]
        public void SimpleStringVar()
        {
            //Arrange
            var template = "{X}";

            //Act
            var result = VariableExtractor.ExtractVariables(XmTemplateDeserializer.Deserialize(template));

            //Assert
            Assert.AreEqual(1, result.Count, template);
            Assert.AreEqual("X", result.Keys.Single(), template);
            Assert.AreEqual("X", result.Values.Single().Name, template);
            Assert.AreEqual(VariableTypeEnum.Text, result.Values.Single().GuessedType, template);
            Assert.AreEqual(false, result.Values.Single().IsArray, template);
            Assert.AreEqual(0, result.Values.Single().Values.Count, template);
        }
        [TestMethod]
        public void SimpleListItemVar()
        {
            //Arrange
            var template = "<EVAL [{S} = \"Cool!\"] />";

            //Act
            var result = VariableExtractor.ExtractVariables(XmTemplateDeserializer.Deserialize(template));

            //Assert
            Assert.AreEqual(1, result.Count, template);
            Assert.AreEqual("S", result.Keys.Single(), template);
            Assert.AreEqual("S", result.Values.Single().Name, template);
            Assert.AreEqual(VariableTypeEnum.ListItem, result.Values.Single().GuessedType, template);
            Assert.AreEqual(false, result.Values.Single().IsArray, template);
            Assert.AreEqual(1, result.Values.Single().Values.Count, template);
            Assert.AreEqual("Cool!", result.Values.Single().Values.Single(), template);
        }
        [TestMethod]
        public void SimpleIntVar()
        {
            //Arrange
            var template = "<EVAL [{N} = \"42\"] />";

            //Act
            var result = VariableExtractor.ExtractVariables(XmTemplateDeserializer.Deserialize(template));

            //Assert
            Assert.AreEqual(1, result.Count, template);
            Assert.AreEqual("N", result.Keys.Single(), template);
            Assert.AreEqual("N", result.Values.Single().Name, template);
            Assert.AreEqual(VariableTypeEnum.Number, result.Values.Single().GuessedType, template);
            Assert.AreEqual(false, result.Values.Single().IsArray, template);
            Assert.AreEqual(1, result.Values.Single().Values.Count, template);
            Assert.AreEqual("42", result.Values.Single().Values.Single(), template);
        }
        [TestMethod]
        public void SimpleBoolVar()
        {
            //Arrange
            var template = "<EVAL [{B} = \"True\"] />";

            //Act
            var result = VariableExtractor.ExtractVariables(XmTemplateDeserializer.Deserialize(template));

            //Assert
            Assert.AreEqual(1, result.Count, template);
            Assert.AreEqual("B", result.Keys.Single(), template);
            Assert.AreEqual("B", result.Values.Single().Name, template);
            Assert.AreEqual(VariableTypeEnum.Boolean, result.Values.Single().GuessedType, template);
            Assert.AreEqual(false, result.Values.Single().IsArray, template);
            Assert.AreEqual(1, result.Values.Single().Values.Count, template);
            Assert.AreEqual("True", result.Values.Single().Values.Single(), template);
        }
        [TestMethod]
        public void SimpleImplicitBoolVar()
        {
            //Arrange
            var template = "<IF [{B}]></IF>";

            //Act
            var result = VariableExtractor.ExtractVariables(XmTemplateDeserializer.Deserialize(template));

            //Assert
            Assert.AreEqual(1, result.Count, template);
            Assert.AreEqual("B", result.Keys.Single(), template);
            Assert.AreEqual("B", result.Values.Single().Name, template);
            Assert.AreEqual(VariableTypeEnum.Boolean, result.Values.Single().GuessedType, template);
            Assert.AreEqual(false, result.Values.Single().IsArray, template);
            Assert.AreEqual(1, result.Values.Single().Values.Count, template);
            Assert.AreEqual("True", result.Values.Single().Values.Single(), template);
        }
        [TestMethod]
        public void ListItemFromInOperator()
        {
            //Arrange
            var stuff = new[] { "Cool!", "LessCool!", "MoreCool!" };
            var template = "<EVAL [{S} IN (\"" + string.Join("\",\"", stuff) + "\")] />";

            //Act
            var result = VariableExtractor.ExtractVariables(XmTemplateDeserializer.Deserialize(template));

            //Assert
            Assert.AreEqual(1, result.Count, template);
            Assert.AreEqual("S", result.Keys.Single(), template);
            Assert.AreEqual("S", result.Values.Single().Name, template);
            Assert.AreEqual(VariableTypeEnum.ListItem, result.Values.Single().GuessedType, template);
            Assert.AreEqual(false, result.Values.Single().IsArray, template);
            Assert.AreEqual(stuff.Length, result.Values.Single().Values.Count, template);
            Assert.AreEqual(false, result.Values.Single().Values.Except(stuff).Any(), template);
        }
        [TestMethod]
        public void ListItemFromInOperatorWithNumbers()
        {
            //Arrange
            var stuff = new[] { "00", "12", "42" };
            var templates = new[]
            {
                "<EVAL [{S} IN (\"" + string.Join("\",\"", stuff) + "\")] />",
                "<IF [{S} IN (\"" + string.Join("\",\"", stuff) + "\")]></IF>",
                "<FOREACH [{X} IN (\"" + string.Join("\",\"", stuff) + "\")]><IF [{S} = {X}]></IF></FOREACH>"
            };

            foreach (var template in templates)
            {
                //Act
                var result = VariableExtractor.ExtractVariables(XmTemplateDeserializer.Deserialize(template));

                //Assert
                Assert.AreEqual(1, result.Count, template);
                Assert.AreEqual("S", result.Keys.Single(), template);
                Assert.AreEqual("S", result.Values.Single().Name, template);
                Assert.AreEqual(VariableTypeEnum.ListItem, result.Values.Single().GuessedType, template);
                Assert.AreEqual(false, result.Values.Single().IsArray, template);
                Assert.AreEqual(stuff.Length, result.Values.Single().Values.Count, template);
                Assert.AreEqual(false, result.Values.Single().Values.Except(stuff).Any(), template);
            }
        }
        [TestMethod]
        public void IntVarFromForLoop()
        {
            //Arrange
            var template = "<FOR [{N} FROM \"1\" TO \"42\"]><IF [{X} < {N}]>{X}</IF></FOR>";

            //Act
            var result = VariableExtractor.ExtractVariables(XmTemplateDeserializer.Deserialize(template));

            //Assert
            Assert.AreEqual(1, result.Count, template);
            Assert.AreEqual("X", result.Keys.Single(), template);
            Assert.AreEqual("X", result.Values.Single().Name, template);
            Assert.AreEqual(VariableTypeEnum.Number, result.Values.Single().GuessedType, template);
            Assert.AreEqual(false, result.Values.Single().IsArray, template);
            Assert.AreEqual(3, result.Values.Single().Values.Count, template);
            Assert.AreEqual(false, result.Values.Single().Values.Except(new [] {"0","1","42"}).Any(), template);
        }
    }
}
