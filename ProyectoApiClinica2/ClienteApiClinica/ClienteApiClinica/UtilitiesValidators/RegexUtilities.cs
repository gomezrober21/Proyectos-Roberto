using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ClienteApiClinica.UtilitiesValidators
{
   public class RegexUtilities
    {
        public static bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }


            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


        public static bool IsPhoneValid(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }

            //return Regex.Match(phone,
            // @"^([\+]?61[-]?|[0])?[1-9][0-9]{8}$").Success;
            return Regex.Match(phone,
            @"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{3})$").Success;
        }


        public static bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            return Regex.Match(name,
          @"^[a-zA-Z]+(\s[a-zA-Z]+)?$").Success;
            //Any whitespace start or end of the name
            //Got symbols e.g. @
            //Less than 2 or more than 30
        }

        public static bool IsNickNameValid(string nickname)
        {
            if (string.IsNullOrWhiteSpace(nickname))
            {
                return false;
            }
            return Regex.Match(nickname,
          "([a-zA-Z,.-]+([a-zA-Z,.-]+)*){2,30}").Success;
            //Any whitespace start or end of the name
            //Got symbols e.g. @
            //Less than 2 or more than 30
        }

        public static bool IsLastName(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                return false;
            }
            return Regex.Match(lastname,
          @"^[a-zA-Z]+(\s[a-zA-Z]+)?$").Success;
            
        }


        public static bool IsPasswordValid(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            return Regex.Match(password,
          @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$").Success;
            //1+ number/1+ lowercase/1+ uppercase
           
        }

        public static bool IsRangeAge(String age)
        {
            if (string.IsNullOrWhiteSpace(age))
            {
                return false;
            }
            return Regex.Match(age,
          @"^(?:1[01][0-9]|120|1[7-9]|[2-9][0-9])$").Success;
            //17 to 120

        }
    }
}
