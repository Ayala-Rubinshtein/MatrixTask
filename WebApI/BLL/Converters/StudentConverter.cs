using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL.Model;
using System.Diagnostics;
using System.Linq;

namespace BLL.converters
{
    class StudentConverter
    {
        public static StudentDTO convertStudentDalToDto(Student s)
        {
            try
            {
                if (s != null)
                    return new StudentDTO()
                    {
                        IDStudent = s.Idstudent,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Id = s.Id,
                        Tel = s.Tel

                    };
                return new StudentDTO();

            }
            catch (Exception e)
            {

                return null;
            }
        }
        public static Student convertStudentDTOToDal(StudentDTO s)
        {
            try
            {
                return new Student()
                {
                    Idstudent = s.IDStudent,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Id = s.Id,
                    Tel = s.Tel
                };

            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static List<Student> convertStudentListDTOToDal(List<StudentDTO> sl)
        {
            try
            {
                var studentList = from u in sl
                                  select convertStudentDTOToDal(u);
                return studentList.ToList();
            }
            catch (Exception e)
            {

                return null;
            }
        }
        public static List<StudentDTO> convertStudentListDalToDTO(List<Student> sl)
        {
            try
            {
                var userList = from u in sl
                               select convertStudentDalToDto(u);
                return userList.ToList();
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
                return null;
            }
        }
    }
}
