using DAL.Classes;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Classes
{
    public class LessonBll
    {
        public  static bool AddLesson(string Name, DateTime BeginDate, float Length, int SchoolID,int MagidID)
        {
            try
            {
                //אם חוזר 0 השיעור כבר קיים
                var newLessonId = LessonDAL.isExistLesson(Name,BeginDate, Length, SchoolID, MagidID);
                if(newLessonId==0)
                {
                    return false;
                }
            }
            catch(Exception e)
            { }
            return true;
        }

        public static List<LessonDTO> getAllLessons(int schoolId)
        {
            return LessonDTO.TOListLessonsDTO(LessonDAL.getAllLessons(schoolId));
        }
    }

}
