using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class LessonDTO
    {
        public int Idlesson { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime FinishDate { get; set; }
        public double Len { get; set; }
        public DateTime CreateDate { get; set; }
        public int Idschool { get; set; }
        public int  Idmagid { get; set; }
        public int Number { get; set; }

        public string NameMagid { get; set; }

        public static LessonDTO ToLessonDTO(Lesson l)
        {

            LessonDTO l1 = new LessonDTO()
            {
                Idlesson = l.Idlesson,
                Name = l.Name!=null?l.Name:"",
                BeginDate = l.BeginDate != null ? ((DateTime)l.BeginDate) : new DateTime(),
                FinishDate = l.FinishDate!=null?(DateTime)l.FinishDate:new DateTime(),
                Len = l.Len!=null?(double)l.Len:0,
                CreateDate = l.CreateDate!=null?(DateTime)l.CreateDate : new DateTime(),
                Idschool =l.Idschool!=null?(int)l.Idschool:0,
                Idmagid = l.Idmagid != null ? (int)l.Idmagid : 0,
                Number = l.Number != null ? (int)l.Number : 0,
                NameMagid = l.Idmag != null ? l.Idmag.Name : ""
    };
            return l1;
        }
        public static List<LessonDTO> TOListLessonsDTO(List<Lesson> ls)
        {
            try
            {
                List<LessonDTO> ls1 = new List<LessonDTO>();
                foreach (var item in ls)
                {
                    ls1.Add(ToLessonDTO(item));
                }
                return ls1;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
