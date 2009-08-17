using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Karkas.Core.Utility
{
    public class FtpYardimcisi
    {
        private string hostName;

        public string HostName
        {
            get { return hostName; }
            set { hostName = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public FtpYardimcisi()
        {

        }


        public FtpYardimcisi(string pHostName, string pUserName, string pPassword)
        {
            this.hostName = pHostName;
            this.userName = pUserName;
            this.password = pPassword;

        }


        private FtpWebRequest ftpWebRequest;

        public FtpWebRequest getFtpWebRequest(string pRemoteFile)
        {
            ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(hostName + pRemoteFile);
            ftpWebRequest.Credentials = new NetworkCredential(UserName, Password);
            ftpWebRequest.KeepAlive = false;
            ftpWebRequest.UseBinary = true;
            return ftpWebRequest;
        }

        public void CreateDirectory(string pRemoteLocation)
        {
            FtpWebRequest request = getFtpWebRequest(pRemoteLocation);
            request.KeepAlive = false;
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            FtpWebResponse FtpResp = (FtpWebResponse)request.GetResponse();
            Stream ftpRespStream = FtpResp.GetResponseStream();

            //close the objects
            request = null;
            ftpRespStream.Close();
        
        }

        public void UpLoadWithFullFileName(string pRemoteLocation, string pLocalFile)
        {
            FtpWebRequest ftp = getFtpWebRequest(pRemoteLocation);
            ftp.Method = WebRequestMethods.Ftp.UploadFile;
            using (FileStream fs = File.OpenRead(pLocalFile))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                using (Stream ftpstream = ftp.GetRequestStream())
                {
                    ftpstream.Write(buffer, 0, buffer.Length);
                }
            }
        }


        public void UpLoadWithDirectoryName(string pDirectoryName, string pLocalFileName)
        {
            UpLoadWithFullFileName(pDirectoryName + "//" + pLocalFileName, pLocalFileName);
        }
    }
}
