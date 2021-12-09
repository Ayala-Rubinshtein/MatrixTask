using System;
using System.Collections.Generic;
using System.Text;
using DAL.Classes;

namespace BLL.Classes
{
    public class OrchotBll
    {
        public static string updateAngGetPoints(string ApiEnterID, string ApiExtension)
        {
            try
            {
                return  OrchotDAL.updateAngGetPoints(ApiEnterID, ApiExtension, "033064837");
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static string TakeCodeFromApiEnterID(string ApiEnterID)
        {
            var x = "";
            if (ApiEnterID.Contains("digits-"))
            {
                x = ApiEnterID.Replace("digits-", "");
                x = x.Trim();
            }
            else
            {
                x = ApiEnterID;
            }
            return x;
        }
        public static int getAllPoints(string ApiEnterID)
        {
            try
            {
                return OrchotDAL.getAllPoints(ApiEnterID);
            }
            catch (Exception e)
            {
                throw e;
           
            }
            
        }
        public static string openTestToStudent(string ApiEnterID, string ApiExtension)
        {
            try
            {
                return OrchotDAL.openTestToStudent(ApiEnterID, ApiExtension);
            }
            catch (Exception e)
            {
                throw e;

            }
        }
        public static string finishTest(string ApiEnterID, string ApiExtension)
        {
            try
            {
                return OrchotDAL.finishTest(ApiEnterID, ApiExtension,"033064837");
            }
            catch (Exception e)
            {
                throw e;

            }
        }

    }
}
