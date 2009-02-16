using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Karkas.Core.Utility
{
    public class FileDownloadHelper
    {
        public static string[] httpHeaderFileDownload = new string[] { "content-disposition", "disposition-type=attachment; filename={0}.{1};Size {2}" };
        public static string[] httpHeaderTarayiciIcinde = new string[] { "content-disposition", "disposition-type=inline;filename={0}.{1}" };

        private TarayiciDavranisiEnum tarayiciDavranisi = TarayiciDavranisiEnum.DosyaIndir;
        public TarayiciDavranisiEnum TarayiciDavranisi
        {
            get
            {
                return tarayiciDavranisi;
            }
            set
            {
                tarayiciDavranisi = value;
            }
        }

        private FileFormats fileFormat;
        /// <summary>
        /// Raporun cikti formati, ornek pdf,xml
        /// </summary>
        public FileFormats FileFormat
        {
            get
            {
                return fileFormat;
            }
            set
            {
                fileFormat = value;
            }
        }


        public string FileName { get; set; }

        public void FileDownload(byte[] pContent)
        {
            switch (TarayiciDavranisi)
            {
                case TarayiciDavranisiEnum.DosyaIndir:
                    FileDownload(httpHeaderFileDownload,pContent);
                    break;
                case TarayiciDavranisiEnum.TarayiciIcindeGoster:
                    FileDownload(httpHeaderTarayiciIcinde,pContent);
                    break;
            }

        }

        internal void FileDownload(string[] yapisi, byte[] pContent)
        {
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;

            switch (FileFormat)
            {
                case FileFormats.PDF:
                    HttpContext.Current.Response.AppendHeader(yapisi[0], string.Format(yapisi[1], FileName, "pdf", pContent.Length));
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    HttpContext.Current.Response.BinaryWrite(pContent);
                    break;
                case FileFormats.IMAGE:
                    HttpContext.Current.Response.AppendHeader(yapisi[0], string.Format(yapisi[1], FileName, "tiff", pContent.Length));
                    HttpContext.Current.Response.ContentType = "image/tiff";
                    HttpContext.Current.Response.BinaryWrite(pContent);
                    break;
                case FileFormats.XML:
                    HttpContext.Current.Response.AppendHeader(yapisi[0], string.Format(yapisi[1], FileName, "xml", pContent.Length));
                    HttpContext.Current.Response.ContentType = "text/xml";
                    HttpContext.Current.Response.BinaryWrite(pContent);
                    break;
                case FileFormats.EXCEL:
                    HttpContext.Current.Response.AppendHeader(yapisi[0], string.Format(yapisi[1], FileName, "xls", pContent.Length));
                    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                    HttpContext.Current.Response.BinaryWrite(pContent);
                    break;
                case FileFormats.TXT:
                    HttpContext.Current.Response.AppendHeader(yapisi[0], string.Format(yapisi[1], FileName, "txt", pContent.Length));
                    HttpContext.Current.Response.ContentType = "text/txt";
                    HttpContext.Current.Response.BinaryWrite(pContent);
                    break;
            }
            HttpContext.Current.Response.End();

        }
    }
    public enum FileFormats
    {
        PDF,
        EXCEL,
        IMAGE,
        XML,
        TXT
    }

    public enum TarayiciDavranisiEnum
    {
        DosyaIndir = 1,
        TarayiciIcindeGoster = 2,
        Attachment = 1,
        Inline = 2
    }

}

