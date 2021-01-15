using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseRateCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            var PeakStart = new DateTime().Add(new TimeSpan(9, 00, 00)).ToString("hh:mm:ss tt");
            var PeakEnd = new DateTime().Add(new TimeSpan(22, 59, 59)).ToString("hh:mm:ss tt");

            var LateOffPickStart = new DateTime().Add(new TimeSpan(24, 00, 00)).ToString("hh:mm:ss tt");
            var LateOffPickEnd = new DateTime().Add(new TimeSpan(8, 59, 59)).ToString("hh:mm:ss tt");
            var EarlyOffPickStart = new DateTime().Add(new TimeSpan(23, 00, 00)).ToString("hh:mm:ss tt");
            var EarlyOffPickEnd = new DateTime().Add(new TimeSpan(23, 59, 59)).ToString("hh:mm:ss tt");

            Console.Write("Start time: ");
            var StartTime = DateTime.Parse(Console.ReadLine()).TimeOfDay;
            Console.Write("End time: ");
            var EndTime = DateTime.Parse(Console.ReadLine()).TimeOfDay;
            TimeSpan TimeDifference = (StartTime - EndTime).Duration();
            double Rate = 0.00;

            if ((StartTime >= DateTime.Parse(PeakStart).TimeOfDay && EndTime <= DateTime.Parse(PeakEnd).TimeOfDay)
                || (StartTime >= DateTime.Parse(PeakStart).TimeOfDay && (EndTime <= DateTime.Parse(EarlyOffPickEnd).TimeOfDay
                || EndTime <= DateTime.Parse(LateOffPickEnd).TimeOfDay)
                || (EndTime <= DateTime.Parse(PeakEnd).TimeOfDay && (StartTime >= DateTime.Parse(EarlyOffPickStart).TimeOfDay
                || StartTime <= DateTime.Parse(LateOffPickEnd).TimeOfDay))))
            {
                Rate = 0.30;
            }
            else if ((StartTime >= DateTime.Parse(EarlyOffPickStart).TimeOfDay && EndTime <= DateTime.Parse(EarlyOffPickEnd).TimeOfDay)
                  || (StartTime >= DateTime.Parse(LateOffPickStart).TimeOfDay && EndTime <= DateTime.Parse(LateOffPickEnd).TimeOfDay))
            {
                Rate = 0.20;   
            }

            double Cost = (TimeDifference.TotalSeconds * Rate) / 20;

            Console.WriteLine("Total Cost: " + Math.Round(Cost, 1,
                                         MidpointRounding.ToEven) + " taka");
            Console.ReadLine();
        }
    }
}
