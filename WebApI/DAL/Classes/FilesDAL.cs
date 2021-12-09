using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
   public class FilesDAL
    {
       

        public static bool DownloadFile(bool? IsPrivateServer,string system, string password, string pathToDownload, string fileName, string pathToSave)
        {
            try
            { 
                using (var client1 = new WebClient())
                {
                    var token = system + ':' + password;
                    var urlStart = "";
                    if (IsPrivateServer == true)
                        urlStart = "https://private.";
                    else
                        urlStart = "https://www.";
                     client1.DownloadFile(urlStart + "call2all.co.il/ym/api/DownloadFile?token=" + token + "&path=ivr2:/" + pathToDownload + '/' + fileName, pathToSave);//0/1/music1.wav", @"d:\Users\User\Downloads\music1.wav");
                                                                                                                                                                        //  Console.WriteLine(readText);
                    Console.WriteLine("content download");
                }
                return true;
            }
            catch (Exception e )
            {

                return false;
            }

        }

       
    }
}
