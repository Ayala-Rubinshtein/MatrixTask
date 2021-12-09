using DAL.Classes;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;


namespace BLL.classes
{
    public class  UserBll
    {
        //private readonly UserDal _User;
        //public UserBll(UserDal User) => _User = User;

        public static  UserDTO GetUserByUserNameAndPassword(string userName, string password)
        {

            var u = UserDal.GetUserByUserNameAndPassword(userName, password);
            if (u != null)
                return converters.UserConverter.convertUserDalToDto(u);
            return null;

        }
    }
}
