namespace Com.Ericmas001.XmTemplating.Conditions.Util
{
    public static class NumberGiver
    {
        private static long m_Num;
        public static string NewNumber()
        {
            return m_Num++.ToString("000000000");
        }
    }
}
