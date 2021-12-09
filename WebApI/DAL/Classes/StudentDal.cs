using DAL.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DAL.Classes
{
    public class StudentDal
    {
        public static List<Student> SelectAllStudents()
        {
            try
            {
                using (VizelContext DB = new VizelContext())
                {
                    return DB.Students.ToList();
                }

            }
            catch (Exception e)
            {
                Trace.TraceError("line 25 in student dal  " + e.Message);
                return null;
            }
        }
    }
}
