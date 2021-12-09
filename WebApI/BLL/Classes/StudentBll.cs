using System;
using System.Collections.Generic;
using System.Text;
using BLL.converters;
using DTO;
using DAL.Classes;

namespace BLL.classes
{
    public class StudentBll
    {
        public static List<StudentDTO> SelectAllStudents()
        {
            return StudentConverter.convertStudentListDalToDTO(StudentDal.SelectAllStudents());
        }
    }
}
