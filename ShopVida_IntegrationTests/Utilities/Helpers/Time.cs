namespace ShopVidaTests.Utilities.Helpers
{
    using System;

    public static class Time
    {
        public static DateTime Parse(string s, string format)
        {
            DateTime dt;
            try
            {
                dt = DateTime.ParseExact(s, format, null);
            }
            catch (FormatException e)
            {
                throw new FormatException(e.Message + $" String: {s}, Expected format: {format}");
            }
            catch (Exception)
            {
                throw;
            }

            return dt;
        }
    }
}