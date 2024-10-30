using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Data.Oracle
{
    public abstract class BaseDalWithoutEntityOracle : BaseDalWithoutEntity<AdoTemplateOracle, ParameterBuilderOracle>
    {
		public BaseDalWithoutEntityOracle(): base(new ExceptionChangerOracle())
		{
			
		}
		public override string ParameterSymbol
        {
            get { return ":"; }
        }

    }
}
