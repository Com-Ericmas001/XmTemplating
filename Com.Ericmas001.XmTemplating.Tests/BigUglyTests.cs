using System;
using System.IO;
using System.Reflection;
using Com.Ericmas001.XmTemplating.Deserialization;
using Com.Ericmas001.XmTemplating.Enums;
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
