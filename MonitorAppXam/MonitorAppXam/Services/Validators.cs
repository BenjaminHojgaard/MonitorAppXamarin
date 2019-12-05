using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace MonitorAppXam.Services
{
    public static class Validators
    {
        static string EmailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                   + "@"
                                   + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

        public static bool ComparePasswords(string passOne, string passTwo)
        {
            return passOne.Equals(passTwo);
        }

        public static bool IsEmail(string email)
        {
            return Regex.IsMatch(email, EmailPattern);
        }
    }
}
