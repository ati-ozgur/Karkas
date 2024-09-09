using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using Karkas.CodeGeneration.Helpers.Interfaces;

namespace Karkas.CodeGeneration.Helpers.PersistenceService
{
    public partial class CodeGenerationConfig 
    {

        public CodeGenerationConfig()
        {
            this.CreationTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            setTimeValues();
        }



        public void setTimeValues()
        {
            this.LastWriteTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"); ;
            this.LastAccessTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"); ;
            
        }

        public string[] getSchemaList()
        {
            return this.SchemaList.Split(",");
        }


        private bool createMainClassValidationExamples = false;

        public bool CreateMainClassValidationExamples
        {
            get { return createMainClassValidationExamples; }
            set { createMainClassValidationExamples = value; }
        }

        private bool createMainClassAgain = false;
        public bool CreateMainClassAgain
        {
            get
            {
                return createMainClassAgain;
            }
            set
            {
                createMainClassAgain = value;
            }

        }

        public override int GetHashCode()
        {
            return ConnectionName.GetHashCode();
        }

        string DatabaseAbbreviations { get; set; }


        public override bool Equals(object obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is CodeGenerationConfig))
            {
                return false;
            }
            return (this.ConnectionName == ((CodeGenerationConfig)obj).ConnectionName);
        }


        public override string ToString()
        {
            return $"{this.ConnectionName}, {this.ConnectionDatabaseType}, {this.ConnectionString}, {this.CodeGenerationDirectory} ";
        }



    }
}
