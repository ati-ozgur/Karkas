using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface ICodeGenerationNotPersistedValues
    {

        bool AnaSinifiTekrarUret { get; set; }
        bool AnaSinifOnaylamaOrnekleriUret { get; set; }

    }
}
