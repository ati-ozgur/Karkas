using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Core.TypeLibrary;

namespace Karkas.Core.DataUtil.BaseClasses
{
    public abstract class BaseDalOracle<T, ADOTEMPLATE_DB_TYPE> : BaseDal<T, ADOTEMPLATE_DB_TYPE> where T : BaseTypeLibrary, new()
    {
        public override string DbProviderName
        {
            get { return "Oracle.DataAccess.Client"; }
        }

        public override string ParameterCharacter
        {
            get
            {
                return ":";
            }
        }
    }
}
