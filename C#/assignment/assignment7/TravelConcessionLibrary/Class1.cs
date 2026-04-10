using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelConcessionLibrary
{
    public class ConcessionCalculator
    {
        public string CalculateConcession(int age, decimal totalFare)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                decimal discountedFare = totalFare - (totalFare * 0.30m);
                return "Senior Citizen - Fare: " + discountedFare;
            }
            else
            {
                return "Ticket Booked - Fare: " + totalFare;
            }
        }
    }
}
namespace TravelConcessionLibrary
{
    public class Class1
    {
    }
}
