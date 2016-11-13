using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Ericmas001.XmTemplating.Tests
{
    [TestClass]
    public class ConditionOperatorsTests
    {
        [TestMethod]
        public void TestEqualSuccess()
        {
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} = \"42\"", new Dictionary<string, string> { { "V", "42" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} == \"42\"", new Dictionary<string, string> { { "V", "42" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} EQ \"42\"", new Dictionary<string, string> { { "V", "42" } });
        }
        [TestMethod]
        public void TestEqualFails()
        {
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} = \"42\"", new Dictionary<string, string> { { "V", "21" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} == \"42\"", new Dictionary<string, string> { { "V", "21" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} EQ \"42\"", new Dictionary<string, string> { { "V", "21" } });
        }
        [TestMethod]
        public void TestNotEqualSuccess()
        {
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} != \"42\"", new Dictionary<string, string> { { "V", "21" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} <> \"42\"", new Dictionary<string, string> { { "V", "21" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} NQ \"42\"", new Dictionary<string, string> { { "V", "21" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} NE \"42\"", new Dictionary<string, string> { { "V", "21" } });
        }
        [TestMethod]
        public void TestNotEqualFails()
        {
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} != \"42\"", new Dictionary<string, string> { { "V", "42" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} <> \"42\"", new Dictionary<string, string> { { "V", "42" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} NQ \"42\"", new Dictionary<string, string> { { "V", "42" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} NE \"42\"", new Dictionary<string, string> { { "V", "42" } });
        }

        [TestMethod]
        public void TestLowerThanSuccess()
        {
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} < \"42\"", new Dictionary<string, string> { { "V", "21" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} LT \"42\"", new Dictionary<string, string> { { "V", "21" } });
        }
        [TestMethod]
        public void TestLowerThanFailsBecauseEqual()
        {
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} < \"42\"", new Dictionary<string, string> { { "V", "42" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} LT \"42\"", new Dictionary<string, string> { { "V", "42" } });
        }
        [TestMethod]
        public void TestLowerThanFailsBecauseGreater()
        {
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} < \"42\"", new Dictionary<string, string> { { "V", "84" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} LT \"42\"", new Dictionary<string, string> { { "V", "84" } });
        }

        [TestMethod]
        public void TestLowerEqualSuccessBecauseLower()
        {
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} <= \"42\"", new Dictionary<string, string> { { "V", "21" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} LE \"42\"", new Dictionary<string, string> { { "V", "21" } });
        }
        [TestMethod]
        public void TestLowerEqualSuccessBecauseEqual()
        {
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} <= \"42\"", new Dictionary<string, string> { { "V", "42" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} LE \"42\"", new Dictionary<string, string> { { "V", "42" } });
        }
        [TestMethod]
        public void TestLowerEqualFailsBecauseGreater()
        {
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} <= \"42\"", new Dictionary<string, string> { { "V", "84" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} LE \"42\"", new Dictionary<string, string> { { "V", "84" } });
        }

        [TestMethod]
        public void TestGreaterEqualSuccessBecauseGreater()
        {
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} >= \"42\"", new Dictionary<string, string> { { "V", "84" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} GE \"42\"", new Dictionary<string, string> { { "V", "84" } });
        }
        [TestMethod]
        public void TestGreaterEqualSuccessBecauseEqual()
        {
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} >= \"42\"", new Dictionary<string, string> { { "V", "42" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} GE \"42\"", new Dictionary<string, string> { { "V", "42" } });
        }
        [TestMethod]
        public void TestGreaterEqualFailsBecauseLower()
        {
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} >= \"42\"", new Dictionary<string, string> { { "V", "21" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} GE \"42\"", new Dictionary<string, string> { { "V", "21" } });
        }

        [TestMethod]
        public void TestGreaterThanSuccessBecauseGreater()
        {
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} > \"42\"", new Dictionary<string, string> { { "V", "84" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} GT \"42\"", new Dictionary<string, string> { { "V", "84" } });
        }
        [TestMethod]
        public void TestGreaterThanFailsBecauseEqual()
        {
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} > \"42\"", new Dictionary<string, string> { { "V", "42" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} GT \"42\"", new Dictionary<string, string> { { "V", "42" } });
        }
        [TestMethod]
        public void TestGreaterThanFailsBecauseLower()
        {
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} > \"42\"", new Dictionary<string, string> { { "V", "21" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} GT \"42\"", new Dictionary<string, string> { { "V", "21" } });
        }
        [TestMethod]
        public void TestAndSuccessBecauseBothTrue()
        {
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} = \"True\" AND \"True\" = \"True\"", new Dictionary<string, string> { { "V", "True" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} = \"True\" && \"True\" = \"True\"", new Dictionary<string, string> { { "V", "True" } });

            EvaluateUtil.EvaluateBooleanCondition(true, "{V} AND \"True\"", new Dictionary<string, string> { { "V", "True" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} && \"True\"", new Dictionary<string, string> { { "V", "True" } });

        }
        [TestMethod]
        public void TestAndFailsBecauseOnlyOneTrue()
        {
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} = \"True\" AND \"True\" = \"True\"", new Dictionary<string, string> { { "V", "False" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} = \"True\" && \"True\" = \"True\"", new Dictionary<string, string> { { "V", "False" } });

            EvaluateUtil.EvaluateBooleanCondition(false, "{V} AND \"True\"", new Dictionary<string, string> { { "V", "False" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} && \"True\"", new Dictionary<string, string> { { "V", "False" } });

        }
        [TestMethod]
        public void TestAndFailsBecauseBothFalse()
        {
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} = \"True\" AND \"False\" = \"True\"", new Dictionary<string, string> { { "V", "False" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} = \"True\" && \"False\" = \"True\"", new Dictionary<string, string> { { "V", "False" } });

            EvaluateUtil.EvaluateBooleanCondition(false, "{V} AND \"False\"", new Dictionary<string, string> { { "V", "False" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} && \"False\"", new Dictionary<string, string> { { "V", "False" } });

        }
        [TestMethod]
        public void TestOrSuccessBecauseBothTrue()
        {
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} = \"True\" OR \"True\" = \"True\"", new Dictionary<string, string> { { "V", "True" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} = \"True\" || \"True\" = \"True\"", new Dictionary<string, string> { { "V", "True" } });

            EvaluateUtil.EvaluateBooleanCondition(true, "{V} OR \"True\"", new Dictionary<string, string> { { "V", "True" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} || \"True\"", new Dictionary<string, string> { { "V", "True" } });

        }
        [TestMethod]
        public void TestOrSuccessBecauseOnlyOneTrue()
        {
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} = \"True\" OR \"True\" = \"True\"", new Dictionary<string, string> { { "V", "False" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} = \"True\" || \"True\" = \"True\"", new Dictionary<string, string> { { "V", "False" } });

            EvaluateUtil.EvaluateBooleanCondition(true, "{V} OR \"True\"", new Dictionary<string, string> { { "V", "False" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} || \"True\"", new Dictionary<string, string> { { "V", "False" } });

        }
        [TestMethod]
        public void TestOrFailsBecauseBothFalse()
        {
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} = \"True\" OR \"False\" = \"True\"", new Dictionary<string, string> { { "V", "False" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} = \"True\" || \"False\" = \"True\"", new Dictionary<string, string> { { "V", "False" } });

            EvaluateUtil.EvaluateBooleanCondition(false, "{V} OR \"False\"", new Dictionary<string, string> { { "V", "False" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} || \"False\"", new Dictionary<string, string> { { "V", "False" } });

        }
        [TestMethod]
        public void TestTrue()
        {
            EvaluateUtil.EvaluateBooleanCondition(true, "{V}", new Dictionary<string, string> { { "V", "True" } });
        }
        [TestMethod]
        public void TestFalse()
        {
            EvaluateUtil.EvaluateBooleanCondition(false, "{V}", new Dictionary<string, string> { { "V", "False" } });
            EvaluateUtil.EvaluateIf(false, "{V}", new Dictionary<string, string> { { "V", "42" } });
            EvaluateUtil.EvaluateIf(false, "{V}", new Dictionary<string, string> { { "V", "SpongeBob" } });
        }
        [TestMethod]
        public void TestStuffThatIsIn()
        {
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} IN (\"Hi\",\"Hello\",\"Hey\")", new Dictionary<string, string> { { "V", "Hi" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} IN (\"Hi\",\"Hello\",\"Hey\")", new Dictionary<string, string> { { "V", "Hello" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} IN (\"Hi\",\"Hello\",\"Hey\")", new Dictionary<string, string> { { "V", "Hey" } });
            EvaluateUtil.EvaluateBooleanCondition(true, "{V} IN {Vs}", new Dictionary<string, string> { { "V", "Hey" } }, new Dictionary<string, IEnumerable<string>> { { "Vs", new[] { "Hi", "Hello", "Hey" } } });
        }
        [TestMethod]
        public void TestStuffThatIsNotIn()
        {
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} IN (\"Hi\",\"Hello\",\"Hey\")", new Dictionary<string, string> { { "V", "Goodbye" } });
            EvaluateUtil.EvaluateBooleanCondition(false, "{V} IN {Vs}", new Dictionary<string, string> { { "V", "Goodbye" } }, new Dictionary<string, IEnumerable<string>> { { "Vs", new[] { "Hi", "Hello", "Hey" } } });
        }
    }
}
