using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Arner.Service.Helper
{
    public static class ValidateHelperClass
    {
        public static bool ValidateName(string name) => Regex.IsMatch(name, @"^[a-zA-Z]+$");
    }
}
