using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;


namespace Karkas.CodeGeneration.Helpers.BaseClasses
{
    public abstract class BaseGenerator
    {

        protected string baseNameSpace;
        protected string classNameTypeLibraryNameSpace;
        protected string classNameTypeLibrary;

        protected string schemaName;


        protected string outputFullFileName;

        protected string outputFullFileNameGenerated;
        protected List<DatabaseAbbreviations> listDatabaseAbbreviations = null;

        protected CodeGenerationConfig codeGenerationConfig;

        public CodeGenerationConfig CodeGenerationConfig { get => codeGenerationConfig; set => codeGenerationConfig = value; }


        protected BaseOutput output;

        public BaseGenerator(CodeGenerationConfig pCodeGenerationConfig)
        {

            codeGenerationConfig = pCodeGenerationConfig;
            output = new BaseOutput();

        }




        protected void AtStartCurlyBraceletIncreaseTab()
        {
            output.AutoTabLine("{");
            output.IncreaseTab();
        }
        protected void AtEndCurlyBraceletDecreaseTab()
        {
            output.DecreaseTab();
            output.AutoTabLine("}");
        }
        protected void AtStartCurlyBracelet()
        {
            output.AutoTabLine("{");
        }
        protected void AtEndCurlyBracelet()
        {
            output.AutoTabLine("}");
        }

        protected void Write_ClassStartCurlyBracelet()
        {
            AtStartCurlyBraceletIncreaseTab();
        }

        protected void Write_ClassEndCurlyBracelet()
        {
            AtEndCurlyBraceletDecreaseTab();
        }
        protected void Write_NamespaceStartCurlyBracelet()
        {
            AtStartCurlyBraceletIncreaseTab();
        }
        protected void Write_NamespaceEndCurlyBracelet()
        {

            if (!CodeGenerationConfig.UseFileScopedNamespace)
            {
                AtEndCurlyBraceletDecreaseTab();
            }
        }

        /// <summary>
        /// Checks if the provided container (table) has a primary key.
		/// Throws an exception if no primary key exists.
		/// This prevents code generation for tables without a primary key.
        /// </summary>
        /// <param name="container">The container to check, which must implement <see cref="IContainer"/>.</param>
        /// <exception cref="Exception">Thrown when the container is a table without a primary key.</exception>
        protected void checkPKExits(IContainer container)
        {
            if (container is ITable && (!((ITable)container).HasPrimaryKey))
            {
                string warningMessage =
                 "Chosen Table " + container.Name + " has NO Primary Key. Code Generation (DAL) only works with tables who has primaryKey.";
                throw new Exception(warningMessage);
            }

        }

		protected void Write_NamespaceStart(string type)
		{
			string nameSpaceToWrite = $"{baseNameSpace}.{type}";

			if (CodeGenerationConfig.UseSchemaNameInNamespaces)
			{
				nameSpaceToWrite += $".{schemaName}";
			}

			output.AutoTab("namespace ");
			output.AutoTab(nameSpaceToWrite);
			if (CodeGenerationConfig.UseFileScopedNamespace)
			{
				output.writeLine(";");
			}
			else
			{
				AtStartCurlyBraceletIncreaseTab();
			}
		}
    }
}

