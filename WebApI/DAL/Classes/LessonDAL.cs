
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class LessonDAL
    {
        public static int isExistLesson(string Name,DateTime BeginDate,float Length,int SchoolID,int MagidID)
        {
            try
            {
                using (VizelContext db = new VizelContext())
                {
                    var isExist = db.Lessons.FirstOrDefault(f => f.BeginDate == BeginDate && f.Idmagid == MagidID && f.Idschool == SchoolID);
                    if (isExist != null)
                    {
                        return 0;
                    }
                }
                    Task task = Task.Run(() =>
                    {
                        using (VizelContext db = new VizelContext())
                        {
                            List<Lesson> allLessonsForMagid = db.Lessons.Where(f => f.Idmagid == MagidID && f.Idschool == SchoolID).ToList();
                            int _max = 0;
                            for (int i = 0; i < allLessonsForMagid.Count; i++)
                            {
                                if ((int)allLessonsForMagid[i].Number > _max)
                                {
                                    _max = (int)allLessonsForMagid[i].Number;
                                }
                            }
                            var lesson = new Lesson();
                            lesson.Name = Name;
                            lesson.BeginDate = BeginDate;
                            lesson.Len = Length;
                            lesson.CreateDate = DateTime.Now;
                            lesson.Idschool = SchoolID;
                            lesson.Idmagid = MagidID;
                            lesson.Number = _max + 1;
                            db.Lessons.Add(lesson);
                            db.SaveChanges();
                        }
                    });
                    return 1;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public static void ApiRequest(string openExt)
        {
            try
            {
                var client = new RestClient(openExt);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static int openLessonsToCurrentDate(int SchoolID)
        {
            try { 

            using (VizelContext db = new VizelContext())
            {

                var token = "0733638677:111222";
                var urlStart = "https://private.call2all.co.il/ym/api/";
                var date=DateTime.UtcNow.AddHours(2).Date;
                List<Lesson> allLessonsForCurrentDate = db.Lessons.Where(f=> f.Idschool == SchoolID &&f.BeginDate==date).ToList();
                for(int i=0;i<allLessonsForCurrentDate.Count;i++)
                {
                        //פותח שלוחה לשיעור
                     var path = "1/" + allLessonsForCurrentDate[i].Idmagid + "/2/";
                     var openExt = urlStart + "UpdateExtension?token=" + token + "&path=ivr2:/"+ path + allLessonsForCurrentDate[i].Number;
                    ApiRequest(openExt);
                   //מעלה את הקובץ EXT
                    var context = urlStart + "UploadTextFile?token=" + token + "&what=ivr2:/" + path + allLessonsForCurrentDate[i].Number
                   + "/ext.ini&contents="
                   + "type=playfile%0Atitle=שיעור " + allLessonsForCurrentDate[i].Number;
                    ApiRequest(context);

                   //מעלה לשיעור אחרון את הניתוב לתיקיה של השיעור שהועלה
                        var context2 = urlStart + "call2all.co.il/ym/api/UploadTextFile?token=" + token + "&what=ivr2:/1/" + (allLessonsForCurrentDate[i].Idmagid) + "/1"
                     + "/ext.ini&contents="
                     + "type=go_to_folder%0Atitle=שיעור אחרון "
                     + "%0Ago_to_folder=/" + path + allLessonsForCurrentDate[i].Number
                     + "%0Alog_playback_play_stop=yes‏%0Aplayfile_log_save=yes%0Alog_playback_play_stop_year_save_folder=yes%0Aplayfile_end_goto=/";
                    
                       
                       ApiRequest(context2);

                    var month = "";
                    if(date.Month.ToString().Length==1)
                    {
                        month = "0" + date.Month;
                    }
                    else
                    {
                        month = date.Month.ToString();
                    }
                    //מעתיק את ההקלטה
                    var NameOfFile = allLessonsForCurrentDate[i].Idmagid +"-"+date.Day+"-"+month+"-"+date.Year;
                    ApiRequest(urlStart + "FileAction?token=" + token + "&action=copy&what=ivr2:/12341234/" + NameOfFile + ".wav&target=ivr2:/" + path+ allLessonsForCurrentDate[i].Number+ "/000.wav");
                    
                        //יוצר שלוחה נוספת בHASH
                        var l = IdListMessageDAL.downloadM(path + "Hash");
                        l.Add(allLessonsForCurrentDate[i].Name+"הקש "+ allLessonsForCurrentDate[i].Number);
                        var context3 = urlStart + "UploadTextFile?token=" + token + "&what=ivr2:/" + path + "Hash"
                        + "/M0000.tts&contents="
                        + string.Join("%0A", l);
                        ApiRequest(context3);

                        //פותח חדר להפניה לשיעור 
                        var openExt2 = urlStart + "UpdateExtension?token=" + token + "&path=ivr2:/" + path + "Hash/"+allLessonsForCurrentDate[i].Number;
                        ApiRequest(openExt2);
                        //מעלה את הקובץ EXT
                        var context4 = urlStart + "UploadTextFile?token=" + token + "&what=ivr2:/" + path + "Hash/" + allLessonsForCurrentDate[i].Number
                       + "/ext.ini&contents="
                       + "type=go_to_folder%0Atitle=שיעור " + allLessonsForCurrentDate[i].Number
                       + "%0Ago_to_folder=/" + path + allLessonsForCurrentDate[i].Number;
                        ApiRequest(context4);
                    }
            }


            new MailSenderDAL().SendEmail("ayala0583211699@gmail.com", "סיימתי להריץ את הפונקציה!!", "messege:" + "כל הכבוד :)");
            return 0;
            }
            catch
            {
                new MailSenderDAL().SendEmail("ayala0583211699@gmail.com", "סיימתי להריץ את הפונקציה!!", "messege:" + "שגיאה :)");
                return 0;
            }
        }

        public static List<Lesson> getAllLessons(int SchoolId)
        {
            try
            {
                using (VizelContext db = new VizelContext())
                {
                    return db.Lessons.Include(m=>m.Idmag).Where(f => f.Idschool == SchoolId).ToList();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static void updateMenu()
        {

        }
    }

}
