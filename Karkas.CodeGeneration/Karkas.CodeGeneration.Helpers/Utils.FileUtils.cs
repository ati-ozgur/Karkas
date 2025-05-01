using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.Helpers
{
    public partial class Utils
    {
        public FileUtils FileUtilsHelper
        {
            get
            {
                return new FileUtils(codeGenerationConfig);
            }
        }


        public class FileUtils
        {
            CodeGenerationConfig codeGenerationConfig;
            public FileUtils(CodeGenerationConfig pCodeGenerationConfig)
            {
                codeGenerationConfig = pCodeGenerationConfig;
            }

            public string GetProjectMainDirectory()
            {
                return codeGenerationConfig.CodeGenerationDirectory;
            }

            public string getBaseNameForBsGenerated(CodeGenerationConfig codeGenerationConfig, string schemaName, string className, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(GetProjectMainDirectory() + Path.DirectorySeparatorChar  + "Bs" + Path.DirectorySeparatorChar  + codeGenerationConfig.ProjectNameSpace + ".Bs" + Path.DirectorySeparatorChar  + schemaName, className + "Bs.generated.cs");
                }
                else
                {
                    return Path.Combine(GetProjectMainDirectory() + Path.DirectorySeparatorChar  + "Bs" + Path.DirectorySeparatorChar  + codeGenerationConfig.ProjectNameSpace + ".Bs" + Path.DirectorySeparatorChar , className + "Bs.generated.cs");
                }
            }
            public string getBaseNameForBs(CodeGenerationConfig codeGenerationConfig, string schemaName, string className, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(GetProjectMainDirectory() + Path.DirectorySeparatorChar  + "Bs" + Path.DirectorySeparatorChar  + codeGenerationConfig.ProjectNameSpace + ".Bs" + Path.DirectorySeparatorChar  + schemaName, className + "Bs.cs");
                }
                else
                {
                    return Path.Combine(GetProjectMainDirectory() + Path.DirectorySeparatorChar  + "Bs" + Path.DirectorySeparatorChar  + codeGenerationConfig.ProjectNameSpace + ".Bs" + Path.DirectorySeparatorChar , className + "Bs.cs");
                }
            }





            public string getBaseNameForDalGenerated(string schemaName, string className, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(GetProjectMainDirectory() + Path.DirectorySeparatorChar  + "Dal" + Path.DirectorySeparatorChar  + codeGenerationConfig.ProjectNameSpace + ".Dal" + Path.DirectorySeparatorChar  + schemaName, className + "Dal.generated.cs");
                }
                else
                {
                    return Path.Combine(GetProjectMainDirectory() + Path.DirectorySeparatorChar  + "Dal" + Path.DirectorySeparatorChar  + codeGenerationConfig.ProjectNameSpace + ".Dal" + Path.DirectorySeparatorChar , className + "Dal.generated.cs");
                }
            }

            public string getBaseNameForSequenceDalGenerated(CodeGenerationConfig codeGenerationConfig, string schemaName, string sequenceName, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(GetProjectMainDirectory() + Path.DirectorySeparatorChar  + "Dal" + Path.DirectorySeparatorChar  + codeGenerationConfig.ProjectNameSpace + ".Dal" + Path.DirectorySeparatorChar  + schemaName + "\\Sequences", sequenceName + "Dal.generated.cs");
                }
                else
                {
                    return Path.Combine(GetProjectMainDirectory() + Path.DirectorySeparatorChar  + "Dal" + Path.DirectorySeparatorChar  + codeGenerationConfig.ProjectNameSpace + ".DalS + Path.DirectorySeparatorChar equences\\", sequenceName + "Dal.generated.cs");
                }
            }


            public string getBaseNameForDal(string schemaName, string className, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(GetProjectMainDirectory() + Path.DirectorySeparatorChar  + "Dal" + Path.DirectorySeparatorChar  + codeGenerationConfig.ProjectNameSpace + ".Dal" + Path.DirectorySeparatorChar  + schemaName, className + "Dal.cs");
                }
                else
                {
                    return Path.Combine(GetProjectMainDirectory() + Path.DirectorySeparatorChar  + "Dal" + Path.DirectorySeparatorChar  + codeGenerationConfig.ProjectNameSpace + ".Dal" + Path.DirectorySeparatorChar , className + "Dal.cs");
                }
            }


            public string getBaseNameForTypeLibraryGenerated(CodeGenerationConfig codeGenerationConfig, string schemaName, string className, bool semaIsminiDizinlerdeKullan)
            {
				string mainDirectory = GetProjectMainDirectory() + Path.DirectorySeparatorChar;
				string typeLibraryDirectory = mainDirectory + "TypeLibrary" + Path.DirectorySeparatorChar; 
				string projectNamescape = codeGenerationConfig.ProjectNameSpace + ".TypeLibrary" + Path.DirectorySeparatorChar;
				string fileName = className + ".generated.cs";

				// TODO refactor for $ usage later
				if (semaIsminiDizinlerdeKullan)
                {

                    return $"{typeLibraryDirectory}{projectNamescape}{schemaName}{Path.DirectorySeparatorChar}{fileName}";

				}
                else
                {
					return $"{typeLibraryDirectory}{projectNamescape}{Path.DirectorySeparatorChar}{fileName}";

				}
			}
            public string getBaseNameForTypeLibrary(CodeGenerationConfig codeGenerationConfig, string schemaName, string className, bool useSchemaNameInFolders)
            {
                if (useSchemaNameInFolders)
                {
                    return Path.Combine(GetProjectMainDirectory() 
                    + Path.DirectorySeparatorChar + 
                    "TypeLibrary" + Path.DirectorySeparatorChar + codeGenerationConfig.ProjectNameSpace + ".TypeLibrary" 
                    + Path.DirectorySeparatorChar + schemaName, 
                    className + ".cs");
                }
                else
                {
                    return Path.Combine(GetProjectMainDirectory() 
                    + Path.DirectorySeparatorChar + "TypeLibrary" + Path.DirectorySeparatorChar + 
                    codeGenerationConfig.ProjectNameSpace + ".TypeLibrary" + Path.DirectorySeparatorChar , className + ".cs");
                }
            }


            // public string getCreateRelationScriptsFullName(ITable table)
            // {
            //     return Path.Combine(GetProjectMainDirectory(table.Database) + "\\Database\\CreateRelationScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".Relations.sql");
            // }

            // public string getCreateScriptsFullName(ITable table)
            // {
            //     return Path.Combine(GetProjectMainDirectory(table.Database) + "\\Database\\CreateScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".CreateTable.sql");
            // }


            // public string getInsertScriptsFullFileName(ITable table)
            // {
            //     return Path.Combine(GetProjectMainDirectory(table.Database) + "\\Database\\InsertScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".Inserts.sql");
            // }



        }
	}
}
