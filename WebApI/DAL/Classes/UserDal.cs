using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace DAL.Classes
{
    public class UserDal
    {
        //private readonly VizelContext _context;
        //public UserDal(VizelContext context) => _context = context;

        public  static User GetUserByUserNameAndPassword(string userName, string password)
        {
            try
            {
                using (VizelContext DB = new VizelContext())
                {
                    return DB.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
