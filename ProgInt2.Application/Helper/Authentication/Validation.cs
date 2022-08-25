using System;
using System.Text.RegularExpressions;

namespace ProgInt2.Application.Helper.Authentication
{
    public static class Validation
    {
        public static bool IsValidPassword(string plainText) {
            Regex regex = new Regex(@"^(.{0,7}|[^0-9]*|[^A-Z])$");
            Match match = regex.Match(plainText);
            return match.Success;
        }
    }
}