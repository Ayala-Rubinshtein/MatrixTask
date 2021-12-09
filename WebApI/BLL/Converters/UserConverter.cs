using DTO;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.converters
{
    public class UserConverter
    {
        public static UserDTO convertUserDalToDto(User u)
        {
            try
            {
                if (u != null)
                    return new UserDTO()
                    {
                        IDUser = u.Iduser,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Password = u.Password,
                        Tz =(int)u.Tz,
                        UserName = u.UserName,
                        Phone = u.Phone,
                        Email = u.Email
                    };
                return new UserDTO();

            }
            catch (Exception e)
            {

                return null;
            }
        }
        public static User convertUserDTOToDal(UserDTO u)
        {
            try
            {
                return new User()
                {
                    Iduser = u.IDUser,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Password = u.Password,
                    Tz = u.Tz,
                    UserName = u.UserName,
                    Phone = u.Phone,
                    Email = u.Email
                };

            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
