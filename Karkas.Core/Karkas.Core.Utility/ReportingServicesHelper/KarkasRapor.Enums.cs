using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.Core.Utility.ReportingServicesHelper
{
    public partial class KarkasRapor
    {
        // TODO NTLM ILE

        public class WebServiceSecurityModelConstants
        {
            public const string BASIC = "Basic";
            public const string DIGEST = "Digest";
            public const string NTLM = "NTLM";
            public const string NEGOTIATE = "Negotiate";
        }
    }

    public enum TarayiciDavranisiEnum
    {
        DosyaIndir = 1,
        TarayiciIcindeGoster = 2,
        Attachment = 1,
        Inline = 2
    }


    public class RaporFormatAsString
    {
        public const string PDF = "PDF";
        public const string EXCEL = "EXCEL";
        public const string IMAGE = "IMAGE";
        public const string TIFF = "TIFF";
        public const string XML = "XML";
    }

    public enum RaporFormats
    {
        PDF,
        EXCEL,
        IMAGE,
        XML
    }
}
