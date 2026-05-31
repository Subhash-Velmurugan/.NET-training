using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TrainReservationBAL
{
    public static class ValidationHelper
    {
        public static bool IsValidUsername(string username)
        {
            return Regex.IsMatch(
                username,
                @"^[A-Za-z0-9]{4,20}$");
        }

        public static bool IsValidPassword(string password)
        {
            return Regex.IsMatch(
                password,
                @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{6,15}$");
        }
    }
}
