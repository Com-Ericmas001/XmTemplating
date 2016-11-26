using System;
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
                new CarsEnumeratorTemplateElement(this),
                new StaticTemplateElement(this) {Content = Environment.NewLine + Environment.NewLine + "Choices:  " + Environment.NewLine},
                new ChoicesEnumeratorTemplateElement(this),
                new StaticTemplateElement(this) {Content = Environment.NewLine + Environment.NewLine + "People" + Environment.NewLine},
                new PeopleEnumeratorTemplateElement(this),
                new StaticTemplateElement(this) {Content = Environment.NewLine + "*******" + Environment.NewLine},
                new ToRangeTemplateElement(this),
                new StaticTemplateElement(this) {Content = "  " + Environment.NewLine + " " + Environment.NewLine},
                new UntilRangeTemplateElement(this),
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
        private class CarsEnumeratorTemplateElement : EnumeratorTemplateElement
        {
            public CarsEnumeratorTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                EnumerationCondition = new OperationConditionPart()
                {
                    LeftSide = new VariableConditionPart { VariableName = "Car" },
                    RightSide = new GroupedConditionPart { Values = new AbstractConditionPart[] { new LiteralConditionPart { Value = "Mercedes" }, new LiteralConditionPart { Value = "Kia" }, new LiteralConditionPart { Value = "Subaru" }, new LiteralConditionPart { Value = "Dodge" }, new LiteralConditionPart { Value = "Mitsubichi" } } },
                    Operator = ConditionPartOperatorEnum.In
                };
                Elements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = Environment.NewLine + "- {Car}   "},
                    new CarIsMyCarConditionalTemplateElement(this),
                    new StaticTemplateElement(this) {Content = Environment.NewLine}
                };
            }
        }
        private class CarIsMyCarConditionalTemplateElement : ConditionalTemplateElement
        {
            public CarIsMyCarConditionalTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                Condition = new OperationConditionPart()
                {
                    LeftSide = new VariableConditionPart { VariableName = "Car" },
                    RightSide = new VariableConditionPart { VariableName = "MyCar" },
                    Operator = ConditionPartOperatorEnum.Equals
                };
                ConditionTrueElements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = "(---- MINE"}
                };
            }
        }
        private class ChoicesEnumeratorTemplateElement : EnumeratorTemplateElement
        {
            public ChoicesEnumeratorTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                EnumerationCondition = new VariableConditionPart { VariableName = "Choice" };
                Elements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = Environment.NewLine + "- {Choice}" + Environment.NewLine}
                };
            }
        }
        private class PeopleEnumeratorTemplateElement : EnumeratorTemplateElement
        {
            public PeopleEnumeratorTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                EnumerationCondition = new VariableConditionPart {VariableName = "Person"};
                Elements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = Environment.NewLine + "Hello I am {Person} ({BigNumber}) "},
                    new BigNumberConditionalTemplateElement(this),
                    new StaticTemplateElement(this) {Content = Environment.NewLine + Environment.NewLine + "*******" + Environment.NewLine},
                    new ChocolatesEnumeratorTemplateElement(this),
                    new StaticTemplateElement(this) {Content = Environment.NewLine},
                };
            }
        }
        private class BigNumberConditionalTemplateElement : ConditionalTemplateElement
        {
            public BigNumberConditionalTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                Condition = new OperationConditionPart()
                {
                    LeftSide = new OperationConditionPart()
                    {
                        LeftSide = new VariableConditionPart { VariableName = "BigNumber" },
                        RightSide = new LiteralConditionPart { Value = "3" },
                        Operator = ConditionPartOperatorEnum.Multiply
                    },
                    RightSide = new LiteralConditionPart { Value = "5" },
                    Operator = ConditionPartOperatorEnum.GreaterThan
                };
                ConditionTrueElements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = "VeryBig Number!!! "},
                    new EvaluateTemplateElement(this) {Expression = new OperationConditionPart()
                    {
                        LeftSide = new VariableConditionPart { VariableName = "BigNumber" },
                        RightSide = new LiteralConditionPart { Value = "5" },
                        Operator = ConditionPartOperatorEnum.Multiply
                    }},
                    new StaticTemplateElement(this) {Content = " {Animal}"}
                };
            }
        }
        private class ChocolatesEnumeratorTemplateElement : EnumeratorTemplateElement
        {
            public ChocolatesEnumeratorTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                EnumerationCondition = new VariableConditionPart { VariableName = "Chocolate" };
                Elements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = Environment.NewLine},
                    new FruitsEnumeratorTemplateElement(this),
                    new StaticTemplateElement(this) {Content = Environment.NewLine},
                };
            }
        }
        private class FruitsEnumeratorTemplateElement : EnumeratorTemplateElement
        {
            public FruitsEnumeratorTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                EnumerationCondition = new VariableConditionPart { VariableName = "Fruit" };
                Elements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = "    " + Environment.NewLine},
                    new BobAndBillyConditionalTemplateElement(this), 
                    new StaticTemplateElement(this) {Content = Environment.NewLine},
                    new ChocolateConditionalTemplateElement(this),
                    new StaticTemplateElement(this) {Content = Environment.NewLine},
                };
            }
        }
        private class BobAndBillyConditionalTemplateElement : ConditionalTemplateElement
        {
            public BobAndBillyConditionalTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                Condition = new OperationConditionPart
                {
                    LeftSide = new OperationConditionPart
                    {
                        LeftSide = new OperationConditionPart
                        {
                            LeftSide = new OperationConditionPart
                            {
                                LeftSide = new VariableConditionPart { VariableName = "Person" },
                                RightSide = new LiteralConditionPart { Value = "Bob" },
                                Operator = ConditionPartOperatorEnum.Different
                            },
                            RightSide = new OperationConditionPart
                            {
                                LeftSide = new VariableConditionPart { VariableName = "Person" },
                                RightSide = new LiteralConditionPart { Value = "Billy" },
                                Operator = ConditionPartOperatorEnum.Different
                            },
                            Operator = ConditionPartOperatorEnum.And
                        },
                        RightSide = new OperationConditionPart
                        {
                            LeftSide = new OperationConditionPart
                            {
                                LeftSide = new VariableConditionPart { VariableName = "Fruit" },
                                RightSide = new LiteralConditionPart { Value = "Orange" },
                                Operator = ConditionPartOperatorEnum.Equals
                            },
                            RightSide = new OperationConditionPart
                            {
                                LeftSide = new LiteralConditionPart { Value = "Kiwi" },
                                RightSide = new VariableConditionPart { VariableName = "Fruit" },
                                Operator = ConditionPartOperatorEnum.Equals
                            },
                            Operator = ConditionPartOperatorEnum.Or
                        },
                        Operator = ConditionPartOperatorEnum.And
                    },
                    RightSide = new OperationConditionPart
                    {
                        LeftSide = new OperationConditionPart
                        {
                            LeftSide = new VariableConditionPart { VariableName = "Fruit" },
                            RightSide = new LiteralConditionPart { Value = "Pineapple" },
                            Operator = ConditionPartOperatorEnum.Equals
                        },
                        RightSide = new OperationConditionPart
                        {
                            LeftSide = new VariableConditionPart { VariableName = "Fruit" },
                            RightSide = new LiteralConditionPart { Value = "Apple" },
                            Operator = ConditionPartOperatorEnum.Equals
                        },
                        Operator = ConditionPartOperatorEnum.Or
                    },
                    Operator = ConditionPartOperatorEnum.Or
                };
                ConditionTrueElements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = Environment.NewLine + "* This {Person} really appreciates {Fruit}" + Environment.NewLine}
                };
            }
        }
        private class ChocolateConditionalTemplateElement : ConditionalTemplateElement
        {
            public ChocolateConditionalTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                Condition = new OperationConditionPart
                {
                    LeftSide = new OperationConditionPart
                    {
                        LeftSide = new OperationConditionPart
                        {
                            LeftSide = new VariableConditionPart { VariableName = "Chocolate" },
                            RightSide = new LiteralConditionPart { Value = "White" },
                            Operator = ConditionPartOperatorEnum.Equals
                        },
                        RightSide = new OperationConditionPart
                        {
                            LeftSide = new VariableConditionPart { VariableName = "Fruit" },
                            RightSide = new LiteralConditionPart { Value = "Lemon" },
                            Operator = ConditionPartOperatorEnum.Equals
                        },
                        Operator = ConditionPartOperatorEnum.And
                    },
                    RightSide = new OperationConditionPart
                    {
                        LeftSide = new OperationConditionPart
                        {
                            LeftSide = new VariableConditionPart { VariableName = "Chocolate" },
                            RightSide = new LiteralConditionPart { Value = "Dark" },
                            Operator = ConditionPartOperatorEnum.Equals
                        },
                        RightSide = new OperationConditionPart
                        {
                            LeftSide = new VariableConditionPart { VariableName = "Fruit" },
                            RightSide = new LiteralConditionPart { Value = "Strawberry" },
                            Operator = ConditionPartOperatorEnum.Equals
                        },
                        Operator = ConditionPartOperatorEnum.And
                    },
                    Operator = ConditionPartOperatorEnum.Or
                };
                ConditionTrueElements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = Environment.NewLine + "*  The mix of {Chocolate} Chocolate and {Fruit} is perfect" + Environment.NewLine}
                };
                ConditionFalseElements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = Environment.NewLine},
                    new BitternessChocolateConditionalTemplateElement(this),
                    new StaticTemplateElement(this) {Content = "   " + Environment.NewLine + "*  this is a cool fruit: {Fruit}" + Environment.NewLine}
                };
            }
        }
        private class BitternessChocolateConditionalTemplateElement : ConditionalTemplateElement
        {
            public BitternessChocolateConditionalTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                Condition = new OperationConditionPart
                {
                    LeftSide = new VariableConditionPart { VariableName = "Chocolate" },
                    RightSide = new GroupedConditionPart { Values = new AbstractConditionPart[] { new LiteralConditionPart { Value = "White" }, new LiteralConditionPart { Value = "Milk" } } },
                    Operator = ConditionPartOperatorEnum.In
                };
                ConditionTrueElements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = "    " + Environment.NewLine + "*  this is sugary chocolate because it's {Chocolate}" + Environment.NewLine}
                };
                ConditionFalseElements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = "         " + Environment.NewLine + "*  this is bitter chocolate because it's {Chocolate}" + Environment.NewLine}
                };
            }
        }
        private class ToRangeTemplateElement : RangeTemplateElement
        {
            public ToRangeTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                Minimum = new VariableConditionPart { VariableName = "Min1" };
                Maximum = new OperationConditionPart
                {
                    LeftSide = new VariableConditionPart { VariableName = "Max1" },
                    RightSide = new LiteralConditionPart { Value = "1" },
                    Operator = ConditionPartOperatorEnum.Subtract
                };
                InludeMaximum = true;
                Elements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = Environment.NewLine},
                    new DefineITemplateElement(this),
                    new StaticTemplateElement(this) {Content = " " + Environment.NewLine + "-)   Counting From {Min1} TO {Max1} : {I}  {FAV}    " + Environment.NewLine}
                };
            }
        }
        private class UntilRangeTemplateElement : RangeTemplateElement
        {
            public UntilRangeTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                Minimum = new VariableConditionPart { VariableName = "Min2" };
                Maximum = new OperationConditionPart
                {
                    LeftSide = new VariableConditionPart { VariableName = "Max2" },
                    RightSide = new LiteralConditionPart { Value = "1" },
                    Operator = ConditionPartOperatorEnum.Add
                };
                InludeMaximum = false;
                Elements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = Environment.NewLine},
                    new DefineITemplateElement(this),
                    new StaticTemplateElement(this) {Content = " " + Environment.NewLine + "-)   Counting From {Min2} UNTIL {Max2} : {I}  {FAV}    " + Environment.NewLine}
                };
            }
        }
        private class DefineITemplateElement : DefineTemplateElement
        {
            public DefineITemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                IsArray = false;
                Variable = new VariableConditionPart {VariableName = "FAV"};
                Elements = new AbstractTemplateElement[]
                {
                    new I42ConditionalTemplateElement(this),
                };
            }
        }
        private class I42ConditionalTemplateElement : ConditionalTemplateElement
        {
            public I42ConditionalTemplateElement(AbstractTemplateElement parent) : base(parent)
            {
                Condition = new OperationConditionPart()
                {
                    LeftSide = new VariableConditionPart { VariableName = "I" },
                    RightSide = new LiteralConditionPart { Value = "42" },
                    Operator = ConditionPartOperatorEnum.Equals
                };
                ConditionTrueElements = new AbstractTemplateElement[]
                {
                    new StaticTemplateElement(this) {Content = "My Favorite Number"}
                };
            }
        }
    }
}
