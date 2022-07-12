using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NeSever.Common.Utils
{
    public class ValidationHelper
    {
        public static bool IsEmailCorrect(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string pattern = "^(|(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\\-+)|([A-Za-z0-9]+\\.+)|([A-Za-z0-9]+\\++))*[A-Za-z0-9]+@((\\w+\\-+)|(\\w+\\.))*\\w{1,63}\\.[a-zA-Z]{2,6})$";
            return Regex.IsMatch(email, pattern, RegexOptions.Compiled);
        }
    }
}
