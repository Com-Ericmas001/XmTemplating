using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Ericmas001.XmTemplating.Tests.TemplateElements
{
    [TestClass]
    public class LoopTests
    {
        [TestMethod]
        public void TestForLoop()
        {
            string expected = string.Concat(Enumerable.Range(0, 20).Select(x => x.ToString()));

            TemplateUtil.EvaluateFor(expected, "{I} FROM \"0\" TO \"19\"","{I}", new Dictionary<string, string>());
            TemplateUtil.EvaluateFor(expected, "{I} FROM \"0\" UNTIL \"20\"", "{I}", new Dictionary<string, string>());
            TemplateUtil.EvaluateFor(expected, "{I} FROM \"0\" TO \"20\" - \"1\"", "{I}", new Dictionary<string, string>());
            TemplateUtil.EvaluateFor(expected, "{I} FROM \"0\" UNTIL \"19\" + \"1\"", "{I}", new Dictionary<string, string>());
            TemplateUtil.EvaluateFor(expected, "{I} FROM \"1\" - \"1\" TO \"19\"", "{I}", new Dictionary<string, string>());
            TemplateUtil.EvaluateFor(expected, "{I} FROM \"1\" - \"1\" UNTIL \"20\"", "{I}", new Dictionary<string, string>());

            TemplateUtil.EvaluateFor(expected, "{I} FROM {MIN} TO \"19\"", "{I}", new Dictionary<string, string> { { "MIN", "0" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM {MIN} UNTIL \"20\"", "{I}", new Dictionary<string, string> { { "MIN", "0" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM {MIN} TO \"20\" - \"1\"", "{I}", new Dictionary<string, string> { { "MIN", "0" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM {MIN} UNTIL \"19\" + \"1\"", "{I}", new Dictionary<string, string> { { "MIN", "0" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM {MIN} - \"1\" TO \"19\"", "{I}", new Dictionary<string, string> { { "MIN", "1" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM {MIN} - \"1\" UNTIL \"20\"", "{I}", new Dictionary<string, string> { { "MIN", "1" } });

            TemplateUtil.EvaluateFor(expected, "{I} FROM \"0\" TO {MAX}", "{I}", new Dictionary<string, string> { { "MAX", "19" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM \"0\" UNTIL {MAX}", "{I}", new Dictionary<string, string> { { "MAX", "20" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM \"0\" TO {MAX} - \"1\"", "{I}", new Dictionary<string, string> { { "MAX", "20" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM \"0\" UNTIL {MAX} + \"1\"", "{I}", new Dictionary<string, string> { { "MAX", "19" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM \"1\" - \"1\" TO {MAX}", "{I}", new Dictionary<string, string> { { "MAX", "19" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM \"1\" - \"1\" UNTIL {MAX}", "{I}", new Dictionary<string, string> { { "MAX", "20" } });

            TemplateUtil.EvaluateFor(expected, "{I} FROM \"0\" TO \"20\" - {OFFSET}", "{I}", new Dictionary<string, string> { { "OFFSET", "1" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM \"0\" UNTIL \"19\" + {OFFSET}", "{I}", new Dictionary<string, string> { { "OFFSET", "1" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM \"1\" - {OFFSET} TO \"19\"", "{I}", new Dictionary<string, string> { { "OFFSET", "1" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM \"1\" - {OFFSET} UNTIL \"20\"", "{I}", new Dictionary<string, string> { { "OFFSET", "1" } });

            TemplateUtil.EvaluateFor(expected, "{I} FROM {MIN} TO {MAX}", "{I}", new Dictionary<string, string> { { "MIN", "0" }, { "MAX", "19" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM {MIN} UNTIL {MAX}", "{I}", new Dictionary<string, string> { { "MIN", "0" }, { "MAX", "20" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM {MIN} TO {MAX} - {OFFSET}", "{I}", new Dictionary<string, string> { { "MIN", "0" }, { "MAX", "20" }, { "OFFSET", "1" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM {MIN} UNTIL {MAX} + {OFFSET}", "{I}", new Dictionary<string, string> { { "MIN", "0" }, { "MAX", "19" }, { "OFFSET", "1" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM {MIN} - {OFFSET} TO {MAX}", "{I}", new Dictionary<string, string> { { "MIN", "1" }, { "MAX", "19" }, { "OFFSET", "1" } });
            TemplateUtil.EvaluateFor(expected, "{I} FROM {MIN} - {OFFSET} UNTIL {MAX}", "{I}", new Dictionary<string, string> { { "MIN", "1" }, { "MAX", "20" }, { "OFFSET", "1" } });
        }

        [TestMethod]
        public void TestForeachLoop()
        {
            string[] stuff = { "Hello", "Hi", "Hey", "Goodbye", "ByeBye", "See ya" };
            string expected = string.Join(",", stuff) + ",";

            TemplateUtil.EvaluateForeach(expected, "{stuff}", "{stuff},", new Dictionary<string, string>(), new Dictionary<string, IEnumerable<string>> { { "stuff", stuff } });
            TemplateUtil.EvaluateForeach(expected, "{stuff} IN (\"Hello\", \"Hi\", \"Hey\", \"Goodbye\", \"ByeBye\", \"See ya\")", "{stuff},", new Dictionary<string, string>(), new Dictionary<string, IEnumerable<string>>());
            TemplateUtil.EvaluateForeach(expected, "{s} IN {stuff}", "{s},", new Dictionary<string, string>(), new Dictionary<string, IEnumerable<string>> { { "stuff", stuff } });
        }
    }
}
