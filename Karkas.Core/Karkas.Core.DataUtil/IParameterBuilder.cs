using System.Data;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    public interface IParameterBuilder
    {
        DbCommand Command { get; set; }

        void AddParameter(string parameterName, DbType dbType, object value);
        void AddParameter(string parameterName, DbType dbType, object value, int size);
        void AddParameterInputOutput(string parameterName, DbType dbType);
        void AddParameterOutput(string parameterName, DbType dbType);
        void AddParameterOutput(string parameterName, DbType dbType, int size);
        void AddParameterReturn(string parameterName, DbType dbType);
        DbParameter[] GetParameterArray();
        string ToString();
    }
}