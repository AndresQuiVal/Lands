using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Text.RegularExpressions;


namespace Lands.Helpers
{
    public static class RegexUtilities
    {
        //We use regular expressions for the code of the class
        public static bool IsValidEmail(string email)
        {
            var expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
