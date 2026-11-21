using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

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

		public BaseDalOracle(DbConnection connection) : base(new ExceptionChangerOracle(), connection)
		{
		}
		public override string DbProviderName
        {
            get { return "Oracle.DataAccess.Client"; }
        }

        /// <summary>
        /// Oracle turns an unquoted CustomerId into CUSTOMERID, so ORDER BY column names are quoted
        /// to match tables created with quoted mixed-case names.
        /// </summary>
        protected override bool QuoteOrderByColumnNames
        {
            get { return true; }
        }

        public override string ParameterCharacter
        {
            get
            {
                return ":";
            }
        }




		protected override string SelectStringWithLimit
		{
			get
			{
				return SelectString + " WHERE ROWNUM <= :maxRowCount";
			}
		}

	}
}
