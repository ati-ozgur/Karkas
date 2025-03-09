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

		public override List<TYPE_LIBRARY_TYPE> QueryAll(int maxRowCount)
		{
			DbCommand cmd = Template.getDatabaseCommand(Connection);
			cmd.CommandText = SelectStringWithLimit;
			DbParameter prm = cmd.CreateParameter();
			prm.ParameterName = ParameterCharacter + "RN";
			prm.Value = maxRowCount;
			cmd.Parameters.Add(prm);
			List<TYPE_LIBRARY_TYPE> liste = new List<TYPE_LIBRARY_TYPE>();
			ExecuteQueryInternal(liste, cmd);
			return liste;

		}


		protected override string SelectStringWithLimit
		{
			get
			{
				return SelectString +  "ROWNUM < :RN";
			}
		}

	}
}
