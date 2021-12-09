using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {

            string val;
            val = Console.ReadLine();

            int res;
            try
            {
                res = Convert.ToInt32(val);
            }
            catch (Exception)
            {
                return;
            }
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i <= res; i++)
            { }

            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds;

            log.Info(DateTime.Today + " – Input:" + res + " – Time: " + stopwatch.Elapsed + " ms");
        }
    }
}
