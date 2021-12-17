using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using System.IO;

namespace Karkas.CodeGenerationHelper
{
    public partial class Utils
    {
        public FileUtils FileUtilsHelper
        {
            get
            {
                return new FileUtils();
            }
        }


        public class FileUtils
        {
            public string ProjeAnaDizininiAl(IDatabase database)
            {
                return database.CodeGenerationDirectory;
            }

            public string getBaseNameForBsWrapperGenerated(IDatabase database, string schemaName, string className, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\BsWrapper\\" + database.ProjectNameSpace + ".BsWrapper\\" + schemaName, className + "BsWrapper.generated.cs");
                }
                else
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\BsWrapper\\" + database.ProjectNameSpace + ".BsWrapper\\", className + "BsWrapper.generated.cs");
                }
            }
            public string getBaseNameForBsWrapper(IDatabase database, string schemaName, string className, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\BsWrapper\\" + database.ProjectNameSpace + ".BsWrapper\\" + schemaName, className + "BsWrapper.cs");
                }
                else
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\BsWrapper\\" + database.ProjectNameSpace + ".BsWrapper\\", className + "BsWrapper.cs");
                }
            }

            public string getBaseNameForBsGenerated(IDatabase database, string schemaName, string className, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Bs\\" + database.ProjectNameSpace + ".Bs\\" + schemaName, className + "Bs.generated.cs");
                }
                else
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Bs\\" + database.ProjectNameSpace + ".Bs\\", className + "Bs.generated.cs");
                }
            }
            public string getBaseNameForBs(IDatabase database, string schemaName, string className, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Bs\\" + database.ProjectNameSpace + ".Bs\\" + schemaName, className + "Bs.cs");
                }
                else
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Bs\\" + database.ProjectNameSpace + ".Bs\\", className + "Bs.cs");
                }
            }





            public string getBaseNameForDalGenerated(IDatabase database, string schemaName, string className, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Dal\\" + database.ProjectNameSpace + ".Dal\\" + schemaName, className + "Dal.generated.cs");
                }
                else
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Dal\\" + database.ProjectNameSpace + ".Dal\\", className + "Dal.generated.cs");
                }
            }

            public string getBaseNameForSequenceDalGenerated(IDatabase database, string schemaName, string sequenceName, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Dal\\" + database.ProjectNameSpace + ".Dal\\" + schemaName + "\\Sequences", sequenceName + "Dal.generated.cs");
                }
                else
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Dal\\" + database.ProjectNameSpace + ".Dal\\Sequences\\", sequenceName + "Dal.generated.cs");
                }
            }


            public string getBaseNameForDal(IDatabase database, string schemaName, string className, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Dal\\" + database.ProjectNameSpace + ".Dal\\" + schemaName, className + "Dal.cs");
                }
                else
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\Dal\\" + database.ProjectNameSpace + ".Dal\\", className + "Dal.cs");
                }
            }


            public string getBaseNameForTypeLibraryGenerated(IDatabase database, string schemaName, string className, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\TypeLibrary\\" + database.ProjectNameSpace + ".TypeLibrary\\" + schemaName, className + ".generated.cs");
                }
                else
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\TypeLibrary\\" + database.ProjectNameSpace + ".TypeLibrary\\", className + ".generated.cs");
                }
            }
            public string getBaseNameForTypeLibrary(IDatabase database, string schemaName, string className, bool semaIsminiDizinlerdeKullan)
            {
                if (semaIsminiDizinlerdeKullan)
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\TypeLibrary\\" + database.ProjectNameSpace + ".TypeLibrary\\" + schemaName, className + ".cs");
                }
                else
                {
                    return Path.Combine(ProjeAnaDizininiAl(database) + "\\TypeLibrary\\" + database.ProjectNameSpace + ".TypeLibrary\\", className + ".cs");
                }
            }


            public string getCreateRelationScriptsFullName(ITable table)
            {
                return Path.Combine(ProjeAnaDizininiAl(table.Database) + "\\Database\\CreateRelationScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".Relations.sql");
            }

            public string getCreateScriptsFullName(ITable table)
            {
                return Path.Combine(ProjeAnaDizininiAl(table.Database) + "\\Database\\CreateScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".CreateTable.sql");
            }


            public string getInsertScriptsFullFileName(ITable table)
            {
                return Path.Combine(ProjeAnaDizininiAl(table.Database) + "\\Database\\InsertScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".Inserts.sql");
            }



        }
	}
}
