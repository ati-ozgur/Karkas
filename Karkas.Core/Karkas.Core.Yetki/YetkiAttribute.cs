using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.Yetki
{
    
    // TODO Hepsine yetkili yada en az birine yetkiliyi nasil yapicaz.
    // 

    [AttributeUsage(AttributeTargets.Class |
     AttributeTargets.Method ,
     AllowMultiple = true)]
    public class YetkiAttribute : Attribute
    {
        public YetkiAttribute(int pYetkiId)
        {
            this.yetkiId = pYetkiId;
        }

        private int yetkiId;

        public int YetkiId
        {
            get { return yetkiId; }
            set { yetkiId = value; }
        }
    }
}

