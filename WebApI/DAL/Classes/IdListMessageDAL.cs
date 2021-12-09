using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DAL.Model;
using RestSharp;

namespace DAL
{
    public class IdListMessageDAL
    {
       
        public static List<string> downloadIdListMessage(User user, string pathToDownload)
        {
            try
            {
                if (!Directory.Exists("Resources"))
                {
                    Directory.CreateDirectory("Resources");
                }
                if (!Directory.Exists("Resources/" + user.Iduser))
                {
                    Directory.CreateDirectory("Resources/" + user.Iduser);
                }
                string fileName = "IdListMessage.ini";
                string pathToSave = "Resources/" + user.Iduser+ "/" + fileName;
                FilesDAL.DownloadFile(user.IsPrivateServer, user.VoiceSystemPhone, user.VoiceSystemPassword, pathToDownload, fileName, pathToSave);
                if (File.Exists(pathToSave))
                {
                    return File.ReadAllLines(pathToSave).ToList();
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<string> downloadM(string pathToDownload)
        {
            try
            {
                if (!Directory.Exists("Resources"))
                {
                    Directory.CreateDirectory("Resources");
                }
                if (!Directory.Exists("Resources/1234"))
                {
                    Directory.CreateDirectory("Resources/1234");
                }
                string fileName = "M0000.tts";
                string pathToSave = "Resources/1234/" + fileName;
                FilesDAL.DownloadFile(true,"0733131111","111222", pathToDownload, fileName, pathToSave);
                if (File.Exists(pathToSave))
                {
                    return File.ReadAllLines(pathToSave).ToList();
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool UploadAnyFileToIvr(bool? IsPrivateServer, string fileAddress, string pathToUpload, string nameToSave, string systemPhone, string password, bool convertToWav = false)
        {
            //var mosad = MosadBLL.CheckIfExsist(systemPhone, password);
            //if (mosad == null) return false;
            var urlStart = "";
            if (IsPrivateServer == true)
                urlStart = "https://private.";
            else
                urlStart = "https://www.";
            var client = new  RestClient(urlStart + "call2all.co.il/ym/api/UploadFile");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AddFile("file", fileAddress);
            request.AddParameter("path", pathToUpload + '/' + nameToSave);
            request.AddParameter("token", systemPhone + ':' + password);
            if (convertToWav)
                request.AddParameter("convertAudio", "1");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void addStudentToIdListMessage(User user, string tz, string pathIdList, string toPath)
        {
            try
            {
                var list = downloadIdListMessage(user, pathIdList);
                list.RemoveAll(r => r.Contains(tz+"="));
                list.Add(tz + "=g-/" + toPath);
                list.RemoveAll(r => r.Contains("***DUP***"));

                Write_ini_premmisions_file(list, pathIdList, user);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static bool Write_ini_premmisions_file(List<string> ls, string pa, User user)
        {
            try
            {
                if (!Directory.Exists("Resources/" + user.Iduser))
                {
                    Directory.CreateDirectory("Resources/" + user.Iduser);
                }
                ls = ls.Where(w => !w.StartsWith('=')).ToList();
                if (ls == null || ls.Count == 0)
                {
                    ls = new List<string>();
                }
                string FileName = "Resources/" + user.Iduser + "/IdListMessage.ini";
                File.WriteAllLines(FileName, ls);
                string path = "ivr2:/";
                if (pa != null)
                    path += pa;
                var upload = UploadAnyFileToIvr(user.IsPrivateServer, FileName, path, "IdListMessage.ini", user.VoiceSystemPhone, user.VoiceSystemPassword);

                return upload;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

    }
}

