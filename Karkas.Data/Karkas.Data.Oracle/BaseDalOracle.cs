using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Data;

namespace Karkas.Data.Oracle
{

    public abstract class BaseDalOracle<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER> :
        BaseDal<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>
        where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new()
        where ADOTEMPLATE_DB_TYPE : IAdoTemplate<IParameterBuilder>, new()
        where PARAMETER_BUILDER : IParameterBuilder, new()

    {

		public BaseDalOracle() : base(new ExceptionChangerOracle())
		{
			
		}
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
