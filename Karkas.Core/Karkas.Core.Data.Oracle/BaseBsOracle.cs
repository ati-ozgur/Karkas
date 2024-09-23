using Karkas.Data;
using Karkas.Data.BaseClasses;





namespace Karkas.Core.Data.Oracle
{

    public class BaseBsOracle<TYPE_LIBRARY_TYPE,DAL_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER> : BaseBs<TYPE_LIBRARY_TYPE, DAL_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER> 
      where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new ()
        where ADOTEMPLATE_DB_TYPE: AdoTemplateOracle, new ()
        where DAL_TYPE : BaseDalOracle<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>, new ()
        where PARAMETER_BUILDER : ParameterBuilderOracle, new ()

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