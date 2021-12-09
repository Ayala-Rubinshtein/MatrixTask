using System;
using System.Collections.Generic;
using System.Text;
using DAL.Classes;

namespace BLL.Classes
{
    public class MekadeshBll
    {
        public static string openTestToPhone(string ApiExtension,string phone)
        {
            try
            {
                return MekadeshDAL.openTestToPhone(ApiExtension,phone);
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        public static string updatePointsAndFinishTest(string ApiExtension,string phone)
        {
            try
            {
                return MekadeshDAL.updatePointsAndFinishTest(ApiExtension, phone, "033064847");
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
