using System.Globalization;

namespace FrameWork.ExMethods
{
    public static class DoubleEx
    {
        public static string ToN3(this double doubl)
        {
            string str = doubl.ToString("N3", new CultureInfo("en-US"));
            str = str.Trim('0').TrimEnd('.'); ;

            if (str == "")
            {
                return "0";
            }
            else
            {
                return str;
            }
        }
    }
}
