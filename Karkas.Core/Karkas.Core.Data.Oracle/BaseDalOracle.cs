using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Core.TypeLibrary;

namespace Karkas.Core.DataUtil.BaseClasses
{
    public abstract class BaseDalOracle<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE> :
        BaseDal<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE> 
        where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new()
        where ADOTEMPLATE_DB_TYPE : AdoTemplate, new()
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
