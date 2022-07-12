using System.Net;

namespace DataPickerProject.Classes
{
    public static class HtmlExtension
    {
        public static string HtmlEncode(this string value)
        {
            value = WebUtility.HtmlEncode(value);
            return value;
        }

        public static string HtmlDecode(this string value)
        {
            value = WebUtility.HtmlDecode(value);
            return value;
        }
    }
}
