﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGeneration.Helpers.Interfaces
{
    public interface ICodeGenerationPersistanceValues
    {

        bool CreateMainClassAgain { get; set; }
        bool CreateMainClassValidationExamples { get; set; }

        string ConnectionName { get; set; }
        string ConnectionDatabaseType { get; set; }
        string ConnectionDbProviderName { get; set; }
        
        string ConnectionString { get; set; }
        string DatabaseNamePhysical { get; set; }
        string DatabaseNameLogical { get; set; }
        string ProjectNameSpace { get; set; }
        string CodeGenerationDirectory { get; set; }

        bool TableCodeGenerate { get; set; }
        bool ViewCodeGenerate { get; set; }
        bool StoredProcedureCodeGenerate { get; set; }
        bool SequenceCodeGenerate { get; set; }

        bool UseSchemaNameInSqlQueries { get; set; }
        bool UseSchemaNameInFolders { get; set; }
        bool IgnoreSystemTables { get; set; }


        string IgnoredSchemaList { get; set; }
        string DatabaseAbbreviations { get; set; }


    }
}
