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
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} == \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} EQ \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
        }
        [TestMethod]
        public void TestEqualFails()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} == \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} EQ \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
        }
        [TestMethod]
        public void TestNotEqualSuccess()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} != \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} <> \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} NQ \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} NE \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
        }
        [TestMethod]
        public void TestNotEqualFails()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} != \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} <> \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} NQ \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} NE \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
        }

        [TestMethod]
        public void TestLowerThanSuccess()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} < \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} LT \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
        }
        [TestMethod]
        public void TestLowerThanFailsBecauseEqual()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} < \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} LT \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
        }
        [TestMethod]
        public void TestLowerThanFailsBecauseGreater()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} < \"42\"", new Dictionary<string, string> { { "V", "84" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} LT \"42\"", new Dictionary<string, string> { { "V", "84" } }, false.ToString());
        }

        [TestMethod]
        public void TestLowerEqualSuccessBecauseLower()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} <= \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} LE \"42\"", new Dictionary<string, string> { { "V", "21" } }, true.ToString());
        }
        [TestMethod]
        public void TestLowerEqualSuccessBecauseEqual()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} <= \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} LE \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
        }
        [TestMethod]
        public void TestLowerEqualFailsBecauseGreater()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} <= \"42\"", new Dictionary<string, string> { { "V", "84" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} LE \"42\"", new Dictionary<string, string> { { "V", "84" } }, false.ToString());
        }

        [TestMethod]
        public void TestGreaterEqualSuccessBecauseGreater()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} >= \"42\"", new Dictionary<string, string> { { "V", "84" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} GE \"42\"", new Dictionary<string, string> { { "V", "84" } }, true.ToString());
        }
        [TestMethod]
        public void TestGreaterEqualSuccessBecauseEqual()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} >= \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} GE \"42\"", new Dictionary<string, string> { { "V", "42" } }, true.ToString());
        }
        [TestMethod]
        public void TestGreaterEqualFailsBecauseLower()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} >= \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} GE \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
        }

        [TestMethod]
        public void TestGreaterThanSuccessBecauseGreater()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} > \"42\"", new Dictionary<string, string> { { "V", "84" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} GT \"42\"", new Dictionary<string, string> { { "V", "84" } }, true.ToString());
        }
        [TestMethod]
        public void TestGreaterThanFailsBecauseEqual()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} > \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} GT \"42\"", new Dictionary<string, string> { { "V", "42" } }, false.ToString());
        }
        [TestMethod]
        public void TestGreaterThanFailsBecauseLower()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} > \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} GT \"42\"", new Dictionary<string, string> { { "V", "21" } }, false.ToString());
        }
        [TestMethod]
        public void TestAndSuccessBecauseBothTrue()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"True\" AND \"True\" = \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"True\" && \"True\" = \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());

            EvaluateUtil.EvaluateBooleanCondition("{V} AND \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} && \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());

        }
        [TestMethod]
        public void TestAndFailsBecauseOnlyOneTrue()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"True\" AND \"True\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"True\" && \"True\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());

            EvaluateUtil.EvaluateBooleanCondition("{V} AND \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} && \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());

        }
        [TestMethod]
        public void TestAndFailsBecauseBothFalse()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"True\" AND \"False\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"True\" && \"False\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());

            EvaluateUtil.EvaluateBooleanCondition("{V} AND \"False\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} && \"False\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());

        }
        [TestMethod]
        public void TestOrSuccessBecauseBothTrue()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"True\" OR \"True\" = \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"True\" || \"True\" = \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());

            EvaluateUtil.EvaluateBooleanCondition("{V} OR \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} || \"True\"", new Dictionary<string, string> { { "V", "True" } }, true.ToString());

        }
        [TestMethod]
        public void TestOrSuccessBecauseOnlyOneTrue()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"True\" OR \"True\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"True\" || \"True\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, true.ToString());

            EvaluateUtil.EvaluateBooleanCondition("{V} OR \"True\"", new Dictionary<string, string> { { "V", "False" } }, true.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} || \"True\"", new Dictionary<string, string> { { "V", "False" } }, true.ToString());

        }
        [TestMethod]
        public void TestOrFailsBecauseBothFalse()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"True\" OR \"False\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} = \"True\" || \"False\" = \"True\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());

            EvaluateUtil.EvaluateBooleanCondition("{V} OR \"False\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
            EvaluateUtil.EvaluateBooleanCondition("{V} || \"False\"", new Dictionary<string, string> { { "V", "False" } }, false.ToString());

        }
        [TestMethod]
        public void TestTrue()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V}", new Dictionary<string, string> { { "V", "True" } }, true.ToString());
        }
        [TestMethod]
        public void TestFalse()
        {
            EvaluateUtil.EvaluateBooleanCondition("{V}", new Dictionary<string, string> { { "V", "False" } }, false.ToString());
        }
    }
}
