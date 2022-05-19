using Karkas.Core.DataUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.Data.Oracle
{
    public class AdoTemplateOracle : AdoTemplate<ParameterBuilderOracle>
    {
        public AdoTemplateOracle()
        {

        }

        public AdoTemplateOracle(string dbProviderName) : base(dbProviderName)
        {
        }
    }
}
