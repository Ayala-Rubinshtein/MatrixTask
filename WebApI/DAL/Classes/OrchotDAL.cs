using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;

namespace DAL.Classes
{
    public class OrchotDAL
    {
        public static string updateAngGetPoints(string EnterId, string ApiExtension,string phone)
        {
            try
            {
                Task task = Task.Run(() =>
                {

                    using (VizelContext db = new VizelContext())
                    {
                        string[] arr = ApiExtension.Split("/");
                        string folder = String.Join("/", arr, 0, arr.Length - 2);
                        var student = db.Students.FirstOrDefault(f => f.Id == EnterId);
                        var test = db.TestOfStudents.FirstOrDefault(f => f.IdStudent == student.Idstudent && f.Folder == folder && f.VoiceSystem==phone);
                        var user=db.Users.FirstOrDefault(f => f.VoiceSystemPhone == phone);
                        string stringToReturn = null;
                        if (test != null)
                        {
                            var question = db.Questions.FirstOrDefault(f => f.Idtest == test.IdTest && f.QuestionNumber == int.Parse(arr[arr.Length - 2]));
                            if (question != null)
                            {
                                if (int.Parse(arr[arr.Length - 1]) == question.NumberOfCurrectAnswer)
                                {
                                    if (test.Score != null)
                                        test.Score += question.Score;
                                    else
                                        test.Score = question.Score;
                                    stringToReturn = "true";
                                }
                                else
                                    stringToReturn = "false";
                            }
                        }
                        db.SaveChanges();
                        string pathIdList = "111/11/" + (int.Parse(arr[2])-1)+"/1";
                        string toPath = "111/1/" + arr[2] +"/" +(int.Parse(arr[3]) + 1);
                        IdListMessageDAL.addStudentToIdListMessage(user, EnterId, pathIdList, toPath);
                        return stringToReturn;
                    }
                }
                );
                return "true";
            }


            catch (Exception e)
            {
                return "";
                throw e;
            }
        }
       
        public static int getAllPoints(string EnterId)
        {
            try
            {
                int num = 0;
                using (VizelContext db = new VizelContext())
                {
                    var student = db.Students.FirstOrDefault(f => f.Id == EnterId);
                    List<TestOfStudent> allTests = db.TestOfStudents.Where(f => f.IdStudent == student.Idstudent && f.VoiceSystem=="033064837").ToList();
                    for (int i = 0; i < allTests.Count(); i++)
                    {
                        num += (int)allTests[i].Score;
                    }
                }
                return num;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
      
        public static string openTestToStudent(string EnterId, string ApiExtension)
        {
            try
            {
                //string[] arr = ApiExtension.Split("/");
                //string folder = String.Join("/", arr, 0, arr.Length - 1);
                Task task = Task.Run(() =>
                {
                    using (VizelContext db = new VizelContext())
                    {
                        var test = db.Tests.FirstOrDefault(f => f.Folder == ApiExtension && f.VoiceSystemPhone=="033064837");
                        var student = db.Students.FirstOrDefault(f => f.Id == EnterId);
                        if (test != null)
                        {
                            var testToStudent = new TestOfStudent();
                            testToStudent.IdTest = test.Idtest;
                            testToStudent.IdStudent = student.Idstudent;
                            testToStudent.Score = 0;
                            testToStudent.BeginDate = DateTime.UtcNow.AddHours(2);
                            testToStudent.BeginTime = null;
                            testToStudent.Folder = ApiExtension;
                            testToStudent.VoiceSystem = "033064837";
                            db.TestOfStudents.Add(testToStudent);
                            db.SaveChanges();
                        }
                    }
                });
                return "ok";

            }
            catch (Exception e)
            {

                throw e;
            }
        }
     
        public static string finishTest(string EnterId, string ApiExtension,string phone)
        {
            try
            {
                string[] arr = ApiExtension.Split("/");
                string folder = String.Join("/", arr, 0, arr.Length - 1);

                using (VizelContext db = new VizelContext())
                {
                    var student = db.Students.FirstOrDefault(f => f.Id == EnterId);
                    var test = db.TestOfStudents.FirstOrDefault(f => f.IdStudent == student.Idstudent && f.Folder == folder && f.VoiceSystem==phone);
                    var user = db.Users.FirstOrDefault(f => f.VoiceSystemPhone == phone);
                    if (test != null)
                    {
                        Task task = Task.Run(() =>
                        {
                            using (VizelContext db = new VizelContext())
                            {
                                var student = db.Students.FirstOrDefault(f => f.Id == EnterId);
                                var test = db.TestOfStudents.FirstOrDefault(f => f.IdStudent == student.Idstudent && f.Folder == folder && f.VoiceSystem == phone);
                                var user = db.Users.FirstOrDefault(f => f.VoiceSystemPhone == phone);
                                test.FinishDate = DateTime.Now;
                                test.FinishTime = null;
                                db.SaveChanges();
                                string pathIdList = "111/11/" + (int.Parse(arr[2]) - 1) + "/1";
                                string toPath = "111/1/" + arr[2] + "/11";
                                IdListMessageDAL.addStudentToIdListMessage(user, EnterId, pathIdList, toPath);
                            }
                        });
                        return test.Score.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                return "";
                throw e;
            }
            return "";
        }
    }
}
    
