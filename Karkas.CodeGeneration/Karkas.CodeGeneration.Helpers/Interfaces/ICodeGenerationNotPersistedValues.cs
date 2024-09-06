using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGeneration.Helpers.Interfaces
{
    public interface ICodeGenerationNotPersistedValues
    {

        bool CreateMainClassAgain { get; set; }
        bool CreateMainClassValidationExamples { get; set; }

    }
}
