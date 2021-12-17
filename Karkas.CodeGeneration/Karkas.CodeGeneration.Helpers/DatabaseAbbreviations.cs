using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper
{
    public class DatabaseAbbreviations
    {
        public string Abbreviation;
        public string FullNameReplacement;
        public string useAsModuleName = "N";

        public DatabaseAbbreviations()
        {

        }

        public DatabaseAbbreviations(string pAbbreviation, string pFullNameReplacement)
        {
            Abbreviation = pAbbreviation;
            FullNameReplacement = pFullNameReplacement;


        }

        public static List<DatabaseAbbreviations> getListDatabaseAbbreviations(string abbrevationsAsString)
        {
            // TODO
            throw new NotImplementedException();
        }


        public override string ToString()
        {
            return string.Format("{0}{1}{2}\n", 
                Abbreviation, "-",
                FullNameReplacement);
        }

        public List<DatabaseAbbreviations> getSampleAbbreviations()
        {

            List<DatabaseAbbreviations> list = new List<DatabaseAbbreviations>();
            DatabaseAbbreviations abbr = new DatabaseAbbreviations();
            abbr.Abbreviation = "BO_";
            abbr.FullNameReplacement = "";
            list.Add(abbr);
            return list;
        }

    }
}
