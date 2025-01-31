using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Business
{
    public class ToDoUnit
    {
        public static double CalculateWorkingDays(DateTime start, DateTime end)
        {
            int resultDays = 0;
            DateTime laufDateTime = start;
            while (laufDateTime <= end)
            {
                if (laufDateTime.DayOfWeek != DayOfWeek.Saturday && laufDateTime.DayOfWeek != DayOfWeek.Sunday)
                {
                    resultDays++;
                }

                laufDateTime = laufDateTime.AddDays(1);
            }

            return resultDays;
        }


        public static double CalculateWorkingDaysFalsch(DateTime start, DateTime end)
        {
            int resultDays = 0;
            int day = start.Day;
            while (day <= end.Day)
            {
                //if (laufDateTime.DayOfWeek != DayOfWeek.Saturday && laufDateTime.DayOfWeek != DayOfWeek.Sunday)
                //{
                //    resultDays++;
                //}

                day++;
            }

            return resultDays;
        }   
    }
}
