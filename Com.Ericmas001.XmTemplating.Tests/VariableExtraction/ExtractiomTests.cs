﻿using Com.Ericmas001.XmTemplating.Enums;
using Com.Ericmas001.XmTemplating.Tests.Util;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Ericmas001.XmTemplating.Tests.VariableExtraction
{
    [TestClass]
    public class ExtractiomTests
    {
        [TestMethod]
        public void SimpleExtractionTest()
        {
            ExtractionVarUtil.TestExtraction("{X}", new ExtractedVariable("X") {GuessedType = VariableTypeEnum.Text});
            ExtractionVarUtil.TestExtraction("<EVAL [{S} = \"Cool!\"] />", new ExtractedVariable("S", "Cool!") {GuessedType = VariableTypeEnum.ListItem});
            ExtractionVarUtil.TestExtraction("<EVAL [{B} = \"True\"] />", new ExtractedVariable("B", "True") {GuessedType = VariableTypeEnum.Boolean});
            ExtractionVarUtil.TestExtraction("<IF [{B}]></IF>", new ExtractedVariable("B", "True") {GuessedType = VariableTypeEnum.Boolean});
            ExtractionVarUtil.TestExtraction("<EVAL [{N} = \"42\"] />", new ExtractedVariable("N", "42") {GuessedType = VariableTypeEnum.Number});
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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
    }
}
