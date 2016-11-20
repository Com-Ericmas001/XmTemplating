using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Ericmas001.XmTemplating.Tests.TemplateElements
{
    [TestClass]
    public class ConditionOperatorsTests
    {
        [TestMethod]
        public void TestEqualSuccess()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} = \"42\"", new Dictionary<string, string> {{"V", "42"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} == \"42\"", new Dictionary<string, string> {{"V", "42"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} EQ \"42\"", new Dictionary<string, string> {{"V", "42"}});
        }

        [TestMethod]
        public void TestEqualFails()
        {
            TemplateUtil.EvaluateBooleanCondition(false, "{V} = \"42\"", new Dictionary<string, string> {{"V", "21"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} == \"42\"", new Dictionary<string, string> {{"V", "21"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} EQ \"42\"", new Dictionary<string, string> {{"V", "21"}});
        }

        [TestMethod]
        public void TestNotEqualSuccess()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} != \"42\"", new Dictionary<string, string> {{"V", "21"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} <> \"42\"", new Dictionary<string, string> {{"V", "21"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} NQ \"42\"", new Dictionary<string, string> {{"V", "21"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} NE \"42\"", new Dictionary<string, string> {{"V", "21"}});
        }

        [TestMethod]
        public void TestNotEqualFails()
        {
            TemplateUtil.EvaluateBooleanCondition(false, "{V} != \"42\"", new Dictionary<string, string> {{"V", "42"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} <> \"42\"", new Dictionary<string, string> {{"V", "42"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} NQ \"42\"", new Dictionary<string, string> {{"V", "42"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} NE \"42\"", new Dictionary<string, string> {{"V", "42"}});
        }

        [TestMethod]
        public void TestLowerThanSuccess()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} < \"42\"", new Dictionary<string, string> {{"V", "21"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} LT \"42\"", new Dictionary<string, string> {{"V", "21"}});
        }

        [TestMethod]
        public void TestLowerThanFailsBecauseEqual()
        {
            TemplateUtil.EvaluateBooleanCondition(false, "{V} < \"42\"", new Dictionary<string, string> {{"V", "42"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} LT \"42\"", new Dictionary<string, string> {{"V", "42"}});
        }

        [TestMethod]
        public void TestLowerThanFailsBecauseGreater()
        {
            TemplateUtil.EvaluateBooleanCondition(false, "{V} < \"42\"", new Dictionary<string, string> {{"V", "84"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} LT \"42\"", new Dictionary<string, string> {{"V", "84"}});
        }

        [TestMethod]
        public void TestLowerEqualSuccessBecauseLower()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} <= \"42\"", new Dictionary<string, string> {{"V", "21"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} LE \"42\"", new Dictionary<string, string> {{"V", "21"}});
        }

        [TestMethod]
        public void TestLowerEqualSuccessBecauseEqual()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} <= \"42\"", new Dictionary<string, string> {{"V", "42"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} LE \"42\"", new Dictionary<string, string> {{"V", "42"}});
        }

        [TestMethod]
        public void TestLowerEqualFailsBecauseGreater()
        {
            TemplateUtil.EvaluateBooleanCondition(false, "{V} <= \"42\"", new Dictionary<string, string> {{"V", "84"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} LE \"42\"", new Dictionary<string, string> {{"V", "84"}});
        }

        [TestMethod]
        public void TestGreaterEqualSuccessBecauseGreater()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} >= \"42\"", new Dictionary<string, string> {{"V", "84"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} GE \"42\"", new Dictionary<string, string> {{"V", "84"}});
        }

        [TestMethod]
        public void TestGreaterEqualSuccessBecauseEqual()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} >= \"42\"", new Dictionary<string, string> {{"V", "42"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} GE \"42\"", new Dictionary<string, string> {{"V", "42"}});
        }

        [TestMethod]
        public void TestGreaterEqualFailsBecauseLower()
        {
            TemplateUtil.EvaluateBooleanCondition(false, "{V} >= \"42\"", new Dictionary<string, string> {{"V", "21"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} GE \"42\"", new Dictionary<string, string> {{"V", "21"}});
        }

        [TestMethod]
        public void TestGreaterThanSuccessBecauseGreater()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} > \"42\"", new Dictionary<string, string> {{"V", "84"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} GT \"42\"", new Dictionary<string, string> {{"V", "84"}});
        }

        [TestMethod]
        public void TestGreaterThanFailsBecauseEqual()
        {
            TemplateUtil.EvaluateBooleanCondition(false, "{V} > \"42\"", new Dictionary<string, string> {{"V", "42"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} GT \"42\"", new Dictionary<string, string> {{"V", "42"}});
        }

        [TestMethod]
        public void TestGreaterThanFailsBecauseLower()
        {
            TemplateUtil.EvaluateBooleanCondition(false, "{V} > \"42\"", new Dictionary<string, string> {{"V", "21"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} GT \"42\"", new Dictionary<string, string> {{"V", "21"}});
        }

        [TestMethod]
        public void TestAndSuccessBecauseBothTrue()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} = \"True\" AND \"True\" = \"True\"", new Dictionary<string, string> {{"V", "True"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} = \"True\" && \"True\" = \"True\"", new Dictionary<string, string> {{"V", "True"}});

            TemplateUtil.EvaluateBooleanCondition(true, "{V} AND \"True\"", new Dictionary<string, string> {{"V", "True"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} && \"True\"", new Dictionary<string, string> {{"V", "True"}});

        }

        [TestMethod]
        public void TestAndFailsBecauseOnlyOneTrue()
        {
            TemplateUtil.EvaluateBooleanCondition(false, "{V} = \"True\" AND \"True\" = \"True\"", new Dictionary<string, string> {{"V", "False"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} = \"True\" && \"True\" = \"True\"", new Dictionary<string, string> {{"V", "False"}});

            TemplateUtil.EvaluateBooleanCondition(false, "{V} AND \"True\"", new Dictionary<string, string> {{"V", "False"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} && \"True\"", new Dictionary<string, string> {{"V", "False"}});

        }

        [TestMethod]
        public void TestAndFailsBecauseBothFalse()
        {
            TemplateUtil.EvaluateBooleanCondition(false, "{V} = \"True\" AND \"False\" = \"True\"", new Dictionary<string, string> {{"V", "False"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} = \"True\" && \"False\" = \"True\"", new Dictionary<string, string> {{"V", "False"}});

            TemplateUtil.EvaluateBooleanCondition(false, "{V} AND \"False\"", new Dictionary<string, string> {{"V", "False"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} && \"False\"", new Dictionary<string, string> {{"V", "False"}});

        }

        [TestMethod]
        public void TestOrSuccessBecauseBothTrue()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} = \"True\" OR \"True\" = \"True\"", new Dictionary<string, string> {{"V", "True"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} = \"True\" || \"True\" = \"True\"", new Dictionary<string, string> {{"V", "True"}});

            TemplateUtil.EvaluateBooleanCondition(true, "{V} OR \"True\"", new Dictionary<string, string> {{"V", "True"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} || \"True\"", new Dictionary<string, string> {{"V", "True"}});

        }

        [TestMethod]
        public void TestOrSuccessBecauseOnlyOneTrue()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} = \"True\" OR \"True\" = \"True\"", new Dictionary<string, string> {{"V", "False"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} = \"True\" || \"True\" = \"True\"", new Dictionary<string, string> {{"V", "False"}});

            TemplateUtil.EvaluateBooleanCondition(true, "{V} OR \"True\"", new Dictionary<string, string> {{"V", "False"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} || \"True\"", new Dictionary<string, string> {{"V", "False"}});

        }

        [TestMethod]
        public void TestOrFailsBecauseBothFalse()
        {
            TemplateUtil.EvaluateBooleanCondition(false, "{V} = \"True\" OR \"False\" = \"True\"", new Dictionary<string, string> {{"V", "False"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} = \"True\" || \"False\" = \"True\"", new Dictionary<string, string> {{"V", "False"}});

            TemplateUtil.EvaluateBooleanCondition(false, "{V} OR \"False\"", new Dictionary<string, string> {{"V", "False"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} || \"False\"", new Dictionary<string, string> {{"V", "False"}});

        }

        [TestMethod]
        public void TestTrue()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V}", new Dictionary<string, string> {{"V", "True"}});
        }

        [TestMethod]
        public void TestFalse()
        {
            TemplateUtil.EvaluateBooleanCondition(false, "{V}", new Dictionary<string, string> {{"V", "False"}});
            TemplateUtil.EvaluateIf(false, "{V}", new Dictionary<string, string> {{"V", "42"}});
            TemplateUtil.EvaluateIf(false, "{V}", new Dictionary<string, string> {{"V", "SpongeBob"}});
        }

        [TestMethod]
        public void TestStuffThatIsIn()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} IN (\"Hi\",\"Hello\",\"Hey\")", new Dictionary<string, string> {{"V", "Hi"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} IN (\"Hi\",\"Hello\",\"Hey\")", new Dictionary<string, string> {{"V", "Hello"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} IN (\"Hi\",\"Hello\",\"Hey\")", new Dictionary<string, string> {{"V", "Hey"}});
            TemplateUtil.EvaluateBooleanCondition(true, "{V} IN {Vs}", new Dictionary<string, string> {{"V", "Hey"}}, new Dictionary<string, IEnumerable<string>> {{"Vs", new[] {"Hi", "Hello", "Hey"}}});
        }

        [TestMethod]
        public void TestStuffThatIsNotIn()
        {
            TemplateUtil.EvaluateBooleanCondition(false, "{V} IN (\"Hi\",\"Hello\",\"Hey\")", new Dictionary<string, string> {{"V", "Goodbye"}});
            TemplateUtil.EvaluateBooleanCondition(false, "{V} IN {Vs}", new Dictionary<string, string> {{"V", "Goodbye"}}, new Dictionary<string, IEnumerable<string>> {{"Vs", new[] {"Hi", "Hello", "Hey"}}});
        }

        [TestMethod]
        public void TestAndOrPriorities()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "\"True\" OR \"True\" AND \"False\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateBooleanCondition(true, "\"True\" OR \"False\" AND \"True\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateBooleanCondition(true, "\"False\" OR \"True\" AND \"True\"", new Dictionary<string, string>());

            TemplateUtil.EvaluateBooleanCondition(false, "(\"True\" OR \"True\") AND \"False\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateBooleanCondition(true, "(\"True\" OR \"False\") AND \"True\"", new Dictionary<string, string>());
            TemplateUtil.EvaluateBooleanCondition(true, "(\"False\" OR \"True\") AND \"True\"", new Dictionary<string, string>());

        }

        [TestMethod]
        public void TestCombinationsOfOr()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} > \"10\" OR {X} IN {Xs} OR {Y} + \"42\" < \"3\" * \"21\" - {Z}",
                new Dictionary<string, string>
                {
                    {"V", "42"},
                    {"X", "Hello"},
                    {"Y", "3"},
                    {"Z", "6"}
                },
                new Dictionary<string, IEnumerable<string>>
                {
                    {"Xs", new[] {"Hi", "Hello", "Hey"}}
                }
                );

            TemplateUtil.EvaluateBooleanCondition(true, "{V} > \"10\" OR {X} IN {Xs} OR {Y} + \"42\" < \"3\" * \"21\" - {Z}",
                new Dictionary<string, string>
                {
                    {"V", "3"},
                    {"X", "Hello"},
                    {"Y", "3"},
                    {"Z", "6"}
                },
                new Dictionary<string, IEnumerable<string>>
                {
                    {"Xs", new[] {"Hi", "Hello", "Hey"}}
                }
                );

            TemplateUtil.EvaluateBooleanCondition(true, "{V} > \"10\" OR {X} IN {Xs} OR {Y} + \"42\" < \"3\" * \"21\" - {Z}",
                new Dictionary<string, string>
                {
                    {"V", "42"},
                    {"X", "GoodBye"},
                    {"Y", "3"},
                    {"Z", "6"}
                },
                new Dictionary<string, IEnumerable<string>>
                {
                    {"Xs", new[] {"Hi", "Hello", "Hey"}}
                }
                );

            TemplateUtil.EvaluateBooleanCondition(true, "{V} > \"10\" OR {X} IN {Xs} OR {Y} + \"42\" < \"3\" * \"21\" - {Z}",
                new Dictionary<string, string>
                {
                    {"V", "42"},
                    {"X", "Hello"},
                    {"Y", "42"},
                    {"Z", "6"}
                },
                new Dictionary<string, IEnumerable<string>>
                {
                    {"Xs", new[] {"Hi", "Hello", "Hey"}}
                }
                );

            TemplateUtil.EvaluateBooleanCondition(false, "{V} > \"10\" OR {X} IN {Xs} OR {Y} + \"42\" < \"3\" * \"21\" - {Z}",
                new Dictionary<string, string>
                {
                    {"V", "3"},
                    {"X", "GoodBye"},
                    {"Y", "42"},
                    {"Z", "6"}
                },
                new Dictionary<string, IEnumerable<string>>
                {
                    {"Xs", new[] {"Hi", "Hello", "Hey"}}
                }
                );
        }

        [TestMethod]
        public void TestCombinationsOfAnd()
        {
            TemplateUtil.EvaluateBooleanCondition(true, "{V} > \"10\" AND {X} IN {Xs} AND {Y} + \"42\" < \"3\" * \"21\" - {Z}",
                new Dictionary<string, string>
                {
                    {"V", "42"},
                    {"X", "Hello"},
                    {"Y", "3"},
                    {"Z", "6"}
                },
                new Dictionary<string, IEnumerable<string>>
                {
                    {"Xs", new[] {"Hi", "Hello", "Hey"}}
                }
                );

            TemplateUtil.EvaluateBooleanCondition(false, "{V} > \"10\" AND {X} IN {Xs} AND {Y} + \"42\" < \"3\" * \"21\" - {Z}",
                new Dictionary<string, string>
                {
                    {"V", "3"},
                    {"X", "Hello"},
                    {"Y", "3"},
                    {"Z", "6"}
                },
                new Dictionary<string, IEnumerable<string>>
                {
                    {"Xs", new[] {"Hi", "Hello", "Hey"}}
                }
                );

            TemplateUtil.EvaluateBooleanCondition(false, "{V} > \"10\" AND {X} IN {Xs} AND {Y} + \"42\" < \"3\" * \"21\" - {Z}",
                new Dictionary<string, string>
                {
                    {"V", "42"},
                    {"X", "GoodBye"},
                    {"Y", "3"},
                    {"Z", "6"}
                },
                new Dictionary<string, IEnumerable<string>>
                {
                    {"Xs", new[] {"Hi", "Hello", "Hey"}}
                }
                );

            TemplateUtil.EvaluateBooleanCondition(false, "{V} > \"10\" AND {X} IN {Xs} AND {Y} + \"42\" < \"3\" * \"21\" - {Z}",
                new Dictionary<string, string>
                {
                    {"V", "42"},
                    {"X", "Hello"},
                    {"Y", "42"},
                    {"Z", "6"}
                },
                new Dictionary<string, IEnumerable<string>>
                {
                    {"Xs", new[] {"Hi", "Hello", "Hey"}}
                }
                );

            TemplateUtil.EvaluateBooleanCondition(false, "{V} > \"10\" AND {X} IN {Xs} AND {Y} + \"42\" < \"3\" * \"21\" - {Z}",
                new Dictionary<string, string>
                {
                    {"V", "3"},
                    {"X", "GoodBye"},
                    {"Y", "42"},
                    {"Z", "6"}
                },
                new Dictionary<string, IEnumerable<string>>
                {
                    {"Xs", new[] {"Hi", "Hello", "Hey"}}
                }
                );
        }
    }
}
