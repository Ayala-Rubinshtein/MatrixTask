using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class MekadeshDAL
    {
        public static string openTestToPhone(string ApiExtension, string phone)
        {
            try
            {
                using (VizelContext db = new VizelContext())
                {
                    var student = db.Students.FirstOrDefault(f => f.Id == phone);
                    if (student != null)
                    {
                        var alltests = db.TestOfStudents.Where(f => f.IdStudent == student.Idstudent && f.VoiceSystem == "033064847").ToList();
                        if(isTestInThisWeek(alltests)==true)
                        {
                            return "go_to_folder=/9999/555";
                        }


                        var test = db.TestOfStudents.FirstOrDefault(f => f.IdStudent == student.Idstudent && f.Folder == ApiExtension && f.VoiceSystem == "033064847");
                        if (test != null)
                        {
                            if (test.FinishDate != null)
                            {
                                return "go_to_folder=/9999/333";
                            }
                        }
                    }
                }
                string[] arr = ApiExtension.Split("/");
                Task task = Task.Run(() =>
                {
                    using (VizelContext db = new VizelContext())
                    {
                        var student = db.Students.FirstOrDefault(f => f.Id == phone);
                        var test = db.Tests.FirstOrDefault(f => f.Folder == ApiExtension && f.VoiceSystemPhone == "033064847");
                        if (test != null)
                        {
                            int studentId;
                            if (student == null)
                            {
                                var newStudent = new Student();
                                newStudent.Id = phone;
                                newStudent.Phone = phone;
                                db.Students.Add(newStudent);
                                db.SaveChanges();
                                studentId = newStudent.Idstudent;
                            }
                            else
                            {
                                studentId = student.Idstudent;
                            }

                            var testToStudent = new TestOfStudent();
                            testToStudent.IdTest = test.Idtest;
                            testToStudent.IdStudent = studentId;
                            testToStudent.Score = 0;
                            testToStudent.BeginDate = DateTime.UtcNow.AddHours(2);
                            testToStudent.BeginTime = null;
                            testToStudent.Folder = ApiExtension;
                            testToStudent.VoiceSystem = "033064847";
                            db.TestOfStudents.Add(testToStudent);
                            db.SaveChanges();

                        }
                    }
                });

                return "go_to_folder=/9999/111/" + arr[arr.Length - 1] + "/1";
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static string updatePointsAndFinishTest(string ApiExtension, string phone, string voiceSystemPhone)
        {
            try
            {
                Task task = Task.Run(() =>
                {

                    using (VizelContext db = new VizelContext())
                    {
                        string[] arr = ApiExtension.Split("/");
                        string folder = String.Join("/", arr, 0, arr.Length - 2);
                        var student = db.Students.FirstOrDefault(f => f.Id == phone);
                        var test = db.TestOfStudents.FirstOrDefault(f => f.IdStudent == student.Idstudent && f.Folder == folder && f.VoiceSystem == voiceSystemPhone);
                        var user = db.Users.FirstOrDefault(f => f.VoiceSystemPhone == voiceSystemPhone);
                        if (test != null)
                        {
                            test.FinishDate = DateTime.Now;
                            if (arr[arr.Length - 1] == "111")
                            {
                                test.Score = 100;
                            }
                        }
                        db.SaveChanges();
                    }
                }
                );
                return "true";
            }


            catch (Exception e)
            {
                throw e;
            }
        }


        public static bool isTestInThisWeek(List<TestOfStudent> allTests)
        {
            DateTime today = DateTime.UtcNow.AddHours(2);
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;

            var d1 = today.Date.AddDays(-1 * (int)cal.GetDayOfWeek(today));

            for (int i=0;i<allTests.Count;i++)
            {
                
                if (allTests[i].FinishDate != null)
                {
                    DateTime finish = (DateTime)allTests[i].FinishDate;
                    var d2 = finish.Date.AddDays(-1 * (int)cal.GetDayOfWeek(finish));
                    if (d1 == d2)
                    {
                        return true;
                    }
                }

            }
            return false;
        }
    }
}
