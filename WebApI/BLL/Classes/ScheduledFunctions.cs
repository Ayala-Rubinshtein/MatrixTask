using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Classes;

namespace BLL
{
    public class ScheduledFunctions
    {
        static CancellationTokenSource m_ctSource;

        public static void RunDailyScheduled(DateTime date)
        {

            Trace.TraceError("Logs!!!!!!!!!!!!!!!!!!!!");
            Trace.TraceError("Hiiiiiiiiii"); 

            m_ctSource = new CancellationTokenSource();
            var dateNow = DateTime.UtcNow.AddHours(2);
            TimeSpan ts;//אובייקט שמייצג את מרווח הזמן שנותר עד להפעלת התהליך
            if (date > dateNow)
                ts = date - dateNow;
            else//אם התאריך המבוקש עבר כבר-מקדם אותו למועד הבא
            {
                date = date.AddDays(1);//קידום התאריך ביום
                ts = date - dateNow;
            }
         
            //שימתין את פרק הזמן שנקבע, ואח"כ יקרא לפונקציה שרצינו שתופעל פעם ב... threadהפעלת ה 
            Task.Delay(ts).ContinueWith((x) =>
            {

                Task.Run(() => LessonDAL.openLessonsToCurrentDate(6));

                date = new DateTime(date.Ticks, DateTimeKind.Local);
                RunDailyScheduled(date);//קריאה חוזרת לפונקציה...
            }, m_ctSource.Token);
        }
    }
}
