using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Com.Ericmas001.XmTemplating.Deserialization;
using Com.Ericmas001.XmTemplating.Enums;
using Com.Ericmas001.XmTemplating.Serialization;
using Com.Ericmas001.XmTemplating.Serialization.Util;
using Com.Ericmas001.XmTemplating.Tests.Resources;
using Com.Ericmas001.XmTemplating.Tests.Util;
using Com.Ericmas001.XmTemplating.Tests.Util.TemplateComparator;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests
{
    [TestFixture]
    public class BigUglyTests
    {
        [Test]
        public void TemplateDeserialization()
        {
            string dirPath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            string filePath = Path.Combine(dirPath, "Resources", "TemplateTest.txt");
            string template = File.ReadAllText(filePath);

            AbstractTemplateComparator.CompareTemplateElements(new TemplateTest(), XmTemplateDeserializer.Deserialize(template));
        }
        [Test]
        public void TemplateSerializationDirty()
        {
            string dirPath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            string filePath = Path.Combine(dirPath, "Resources", "TemplateTest.txt");
            string template = File.ReadAllText(filePath);

            var vars = new Dictionary<string, string>
                    {
                        {"CoolStuff", "I'm cool"},
                        {"IsMyBuddy", "True"},
                        {"BigNumber", "25"},
                        {"Min1", "21"},
                        {"Max1", "25"},
                        {"Min2", "42"},
                        {"Max2", "50"},
                        {"MyCar", "Subaru"},
                        {"DoraCar", "Kia"},
                    };
            var arrays = new Dictionary<string, IEnumerable<string>>
                    {
                        {"Chocolate", new[] {"Dark", "White", "75%", "Milk", "Very Dark"}},
                        {"Fruit", new[] {"Orange", "Lemon", "Pineapple", "Strawberry", "Kiwi"}},
                        {"Person", new[] {"Billy", "Bob", "Julia"}}
                    };

            string resFilePath = Path.Combine(dirPath, "Resources", "TemplateTestResult.txt");
            string expectedResult = File.ReadAllText(resFilePath);
            Assert.AreEqual(expectedResult, XmTemplateSerializer.Serialize(XmTemplateDeserializer.Deserialize(template), vars, arrays, new TemplateSerializationParms { RemoveEmptyLines = false, TrimEndOfLines = false}));
        }
        [Test]
        public void TemplateSerializationClean()
        {
            string dirPath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            string filePath = Path.Combine(dirPath, "Resources", "TemplateTest.txt");
            string template = File.ReadAllText(filePath);

            var vars = new Dictionary<string, string>
                    {
                        {"CoolStuff", "I'm cool"},
                        {"IsMyBuddy", "True"},
                        {"BigNumber", "25"},
                        {"Min1", "21"},
                        {"Max1", "25"},
                        {"Min2", "42"},
                        {"Max2", "50"},
                        {"MyCar", "Subaru"},
                        {"DoraCar", "Kia"},
                    };
            var arrays = new Dictionary<string, IEnumerable<string>>
                    {
                        {"Chocolate", new[] {"Dark", "White", "75%", "Milk", "Very Dark"}},
                        {"Fruit", new[] {"Orange", "Lemon", "Pineapple", "Strawberry", "Kiwi"}},
                        {"Person", new[] {"Billy", "Bob", "Julia"}}
                    };

            string resFilePath = Path.Combine(dirPath, "Resources", "TemplateTestResultClean.txt");
            string expectedResult = File.ReadAllText(resFilePath);
            Assert.AreEqual(expectedResult, XmTemplateSerializer.Serialize(XmTemplateDeserializer.Deserialize(template), vars, arrays));
        }
        [Test]
        public void VariableExtractionTest()
        {
            string dirPath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            string filePath = Path.Combine(dirPath, "Resources", "TemplateTest.txt");
            string template = File.ReadAllText(filePath);

            ExtractionVarUtil.TestExtraction(template, new[]
            {
                new ExtractedVariable("IsMyBuddy", "True") {GuessedType = VariableTypeEnum.Boolean, IsArray = false},
                new ExtractedVariable("MyCar", "Mercedes", "Kia", "Subaru", "Dodge", "Mitsubichi") {GuessedType = VariableTypeEnum.ListItem, IsArray = false},
                new ExtractedVariable("Chocolate", "Dark", "Milk", "White") {GuessedType = VariableTypeEnum.ListItem, IsArray = true},
                new ExtractedVariable("Fruit", "Orange", "Kiwi", "Pineapple", "Apple", "Lemon", "Strawberry") {GuessedType = VariableTypeEnum.ListItem, IsArray = true},
                new ExtractedVariable("Person", "Bob", "Billy") {GuessedType = VariableTypeEnum.ListItem, IsArray = true},
                new ExtractedVariable("BigNumber", "3", "5") {GuessedType = VariableTypeEnum.Number, IsArray = false},
                new ExtractedVariable("CoolStuff") {GuessedType = VariableTypeEnum.Text, IsArray = false},
                new ExtractedVariable("DoraCar", "Mercedes", "Kia", "Subaru", "Dodge", "Mitsubichi") {GuessedType = VariableTypeEnum.ListItem, IsArray = false},
                new ExtractedVariable("Max1", "0", "1", "42") {GuessedType = VariableTypeEnum.Number, IsArray = false},
                new ExtractedVariable("Max2", "0", "1", "42") {GuessedType = VariableTypeEnum.Number, IsArray = false},
                new ExtractedVariable("Min1", "0", "1", "42") {GuessedType = VariableTypeEnum.Number, IsArray = false},
                new ExtractedVariable("Min2", "0", "1", "42") {GuessedType = VariableTypeEnum.Number, IsArray = false}
            });
        }
    }
}
