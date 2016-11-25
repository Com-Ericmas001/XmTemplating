using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Tests.Resources
{
    public class TemplateTest : XmTemplateElement
    {
        public TemplateTest()
        {
            Elements = new AbstractTemplateElement[]
            {
                new AnimalDefineTemplateElement(this),
                new StaticTemplateElement(this) {Content = Environment.NewLine},
                new ChoiceDefineTemplateElement(this),
                new StaticTemplateElement(this) {Content = Environment.NewLine + "Hey "},
                new BuddyConditionalTemplateElement(this),
                new StaticTemplateElement(this) {Content = Environment.NewLine + "This is some cool stuff: {CoolStuff}" + Environment.NewLine + Environment.NewLine + "Cars:" + Environment.NewLine},
                new EnumeratorTemplateElement(this),
                new StaticTemplateElement(this) {Content = Environment.NewLine + Environment.NewLine + "Choices:  " + Environment.NewLine},
                new EnumeratorTemplateElement(this),
                new StaticTemplateElement(this) {Content = Environment.NewLine + Environment.NewLine + "People" + Environment.NewLine},
                new EnumeratorTemplateElement(this),
                new StaticTemplateElement(this) {Content = Environment.NewLine + "*******" + Environment.NewLine},
                new RangeTemplateElement(this),
                new StaticTemplateElement(this) {Content = "  " + Environment.NewLine + " " + Environment.NewLine},
                new RangeTemplateElement(this),
                new StaticTemplateElement(this) {Content = Environment.NewLine},
                new DoraCarConditionalTemplateElement(this),
            };
        }
        private class AnimalDefineTemplateElement : DefineTemplateElement
        {
            public AnimalDefineTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                IsArray = false;
                Variable = new VariableConditionPart { VariableName = "Animal" };
                Elements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = "Rabbit"}
                };
            }
        }
        private class ChoiceDefineTemplateElement : DefineTemplateElement
        {
            public ChoiceDefineTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                IsArray = true;
                Variable = new VariableConditionPart { VariableName = "Choice" };
                Elements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = Environment.NewLine + "Choice1" + Environment.NewLine + "Choice2" + Environment.NewLine + "Choice3" + Environment.NewLine + "BadChoice" + Environment.NewLine}
                };
            }
        }
        private class BuddyConditionalTemplateElement : ConditionalTemplateElement
        {
            public BuddyConditionalTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                Condition = new OperationConditionPart()
                {
                    LeftSide = new VariableConditionPart { VariableName = "IsMyBuddy" },
                    RightSide = new LiteralConditionPart { Value = "True" },
                    Operator = ConditionPartOperatorEnum.Equals
                };
                ConditionTrueElements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = "buddy !"}
                };
                ConditionFalseElements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = "you,"}
                };
            }
        }
        private class DoraCarConditionalTemplateElement : ConditionalTemplateElement
        {
            public DoraCarConditionalTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                Condition = new OperationConditionPart()
                {
                    LeftSide = new VariableConditionPart { VariableName = "DoraCar" },
                    RightSide = new VariableConditionPart { VariableName = "MyCar" },
                    Operator = ConditionPartOperatorEnum.Equals
                };
                ConditionTrueElements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = "{DoraCar} is like mine "}
                };
            }
        }
    }
}
