using Karkas.Data;
using Karkas.Data.Base;


using Microsoft.Data.Sqlite;


namespace Karkas.Data.Sqlite
{

    public class BaseBsSqliteForIdentity<TYPE_LIBRARY_TYPE, DAL_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER, PRIMARY_KEY>         
        : BaseBsForIdentity<TYPE_LIBRARY_TYPE, DAL_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER, PRIMARY_KEY>
        where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new()
        where DAL_TYPE : BaseDalForIdentity<TYPE_LIBRARY_TYPE, PRIMARY_KEY, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>, new()
        where ADOTEMPLATE_DB_TYPE : IAdoTemplate<IParameterBuilder>, new()
        where PARAMETER_BUILDER : IParameterBuilder, new()
        where PRIMARY_KEY : struct

    {
        public new DIGER_DAL_TIPI GetDalInstance<DIGER_DAL_TIPI, DIGER_TYPE_LIBRARY_TIPI>()
            where DIGER_TYPE_LIBRARY_TIPI : BaseTypeLibrary, new()
            where DIGER_DAL_TIPI : BaseDal<DIGER_TYPE_LIBRARY_TIPI, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>, new()
        {
            DIGER_DAL_TIPI di = new DIGER_DAL_TIPI();
            di.Connection = Connection;
            di.IsInTransaction = IsInTransaction;
            if (IsInTransaction)
            {
                di.AutomaticConnectionManagement = false;
                di.CurrentTransaction = transaction;
            }
            return di;
        }

    }
}