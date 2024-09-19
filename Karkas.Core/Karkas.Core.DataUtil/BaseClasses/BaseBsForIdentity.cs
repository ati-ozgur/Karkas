using System;

namespace Karkas.Core.DataUtil.BaseClasses;

public abstract class BaseBsForIdentity<TYPE_LIBRARY_TYPE, DAL_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER,PRIMARY_KEY> : BaseBs<TYPE_LIBRARY_TYPE,DAL_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>
    where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new()
    where ADOTEMPLATE_DB_TYPE : IAdoTemplate<IParameterBuilder>, new()
    where DAL_TYPE : BaseDalForIdentity<TYPE_LIBRARY_TYPE, PRIMARY_KEY, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>, new()
    where PARAMETER_BUILDER : IParameterBuilder, new()
    where PRIMARY_KEY : struct
{
    public new virtual PRIMARY_KEY Insert(TYPE_LIBRARY_TYPE k)
    {
        return dal.Insert(k);
    }
}