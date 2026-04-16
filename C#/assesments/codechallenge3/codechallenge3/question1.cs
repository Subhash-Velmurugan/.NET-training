using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codechallenge3
{
    internal class CricketTeam
    {
        public (int m,int sum,double avg) pointscalculation(int n)
        {
            int m = n;
            int sum = 0;
            for(int i=0;i<n; i++)
            {
                sum+=int.Parse(Console.ReadLine());
            }
            double avg = sum / m;
            return (m,sum,avg);
        }
        public static void Main(string[] args)
        {
            Console.Write("Enter no of matches: ");
            int n=int.Parse(Console.ReadLine());
            CricketTeam CricketTeam = new CricketTeam();
            var result = CricketTeam.pointscalculation(n);
            Console.WriteLine("Total matches: "+result.m);
            Console.WriteLine("Total points: "+result.sum); 
            Console.WriteLine("avg points: "+result.avg);
        }
    }
}
