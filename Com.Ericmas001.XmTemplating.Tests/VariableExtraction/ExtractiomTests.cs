using System;
using System.IO;
using System.Reflection;
using Com.Ericmas001.XmTemplating.Enums;
using Com.Ericmas001.XmTemplating.Tests.Util;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.VariableExtraction
{
    [TestFixture]
    public class ExtractiomTests
    {
        [Test]
        public void SimpleExtractionTest()
        {
            ExtractionVarUtil.TestExtraction("{X}", new ExtractedVariable("X") { GuessedType = VariableTypeEnum.Text });
            ExtractionVarUtil.TestExtraction("<EVAL [{S} = \"Cool!\"] />", new ExtractedVariable("S", "Cool!") { GuessedType = VariableTypeEnum.ListItem });
            ExtractionVarUtil.TestExtraction("<EVAL [{B} = \"True\"] />", new ExtractedVariable("B", "True") { GuessedType = VariableTypeEnum.Boolean });
            ExtractionVarUtil.TestExtraction("<IF [{B}]></IF>", new ExtractedVariable("B", "True") { GuessedType = VariableTypeEnum.Boolean });
            ExtractionVarUtil.TestExtraction("<EVAL [{N} = \"42\"] />", new ExtractedVariable("N", "42") { GuessedType = VariableTypeEnum.Number });
        }

        [Test]
        public void NumberExtractionTest()
        {
            ExtractionVarUtil.TestExtraction("<EVAL [{N} = \"42\" OR {N} = \"21\" OR {N} = \"84\"] />", new ExtractedVariable("N", "42", "21", "84") { GuessedType = VariableTypeEnum.Number });
            ExtractionVarUtil.TestExtraction("<EVAL [{N} = \"84\" OR ({N} > \"21\" AND {N} < \"42\")] />", new ExtractedVariable("N", "42", "21", "84") { GuessedType = VariableTypeEnum.Number });
        }

        [Test]
        public void StringsAndInOperatorsExtractionTest()
        {
            var stuff = new[] {"Cool!", "LessCool!", "MoreCool!"};
            var templates = new[]
            {
                "<EVAL [{S} IN (\"" + string.Join("\",\"", stuff) + "\")] />",
                "<IF [{S} IN (\"" + string.Join("\",\"", stuff) + "\")]></IF>",
                "<FOREACH [{X} IN (\"" + string.Join("\",\"", stuff) + "\")]><IF [{S} = {X}]></IF></FOREACH>"
            };
            ExtractionVarUtil.TestExtraction(templates, new ExtractedVariable("S", stuff) {GuessedType = VariableTypeEnum.ListItem});
        }

        [Test]
        public void NumbersAndInOperatorsExtractionTest()
        {
            var stuff = new[] {"00", "12", "42"};
            var templates = new[]
            {
                "<EVAL [{N} IN (\"" + string.Join("\",\"", stuff) + "\")] />",
                "<IF [{N} IN (\"" + string.Join("\",\"", stuff) + "\")]></IF>",
                "<FOREACH [{X} IN (\"" + string.Join("\",\"", stuff) + "\")]><IF [{N} = {X}]></IF></FOREACH>"
            };
            ExtractionVarUtil.TestExtraction(templates, new ExtractedVariable("N", stuff) {GuessedType = VariableTypeEnum.ListItem});
        }

        [Test]
        public void IntVarFromForLoop()
        {
            ExtractionVarUtil.TestExtraction("<FOR [{N} FROM \"1\" TO \"42\"]><IF [{X} < {N}]>{X}</IF></FOR>", new ExtractedVariable("X", "0", "1", "42") {GuessedType = VariableTypeEnum.Number});

            ExtractionVarUtil.TestExtraction("<FOR [{N} FROM {min} TO \"42\"]><IF [{X} < {N}]>{X}</IF></FOR>", new[]
            {
                new ExtractedVariable("X", "0", "42") {GuessedType = VariableTypeEnum.Number},
                new ExtractedVariable("min", "0", "42") {GuessedType = VariableTypeEnum.Number}
            });

            ExtractionVarUtil.TestExtraction("<FOR [{N} FROM \"1\" TO {max}]><IF [{X} < {N}]>{X}</IF></FOR>", new[]
            {
                new ExtractedVariable("X", "0", "1") {GuessedType = VariableTypeEnum.Number},
                new ExtractedVariable("max", "0", "1") {GuessedType = VariableTypeEnum.Number}
            });

            ExtractionVarUtil.TestExtraction("<FOR [{N} FROM {min} TO {max}]><IF [{X} < {N}]>{X}</IF></FOR>", new[]
            {
                new ExtractedVariable("X", "0") {GuessedType = VariableTypeEnum.Number},
                new ExtractedVariable("min", "0") {GuessedType = VariableTypeEnum.Number},
                new ExtractedVariable("max", "0") {GuessedType = VariableTypeEnum.Number}
            });

            ExtractionVarUtil.TestExtraction("<FOR [{N} FROM {min} TO {max}]></FOR>", new[]
            {
                new ExtractedVariable("min", "0") {GuessedType = VariableTypeEnum.Number},
                new ExtractedVariable("max", "0") {GuessedType = VariableTypeEnum.Number}
            });
        }

        [Test]
        public void BigUglyTest()
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
