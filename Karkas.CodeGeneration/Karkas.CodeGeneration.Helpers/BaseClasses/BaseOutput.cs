using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGeneration.Helpers.Interfaces;
using System.IO;

namespace Karkas.CodeGeneration.Helpers.BaseClasses
{
    public class BaseOutput : IOutput
    {

        StringBuilder buffer = new StringBuilder(1000);
        private int _tabLevel = 0;

        public int TabLevel
        {
            get
            {
                return _tabLevel;
            }
            set
            {
                _tabLevel = value;
            }
        }

        private void writeNewLine()
        {
            buffer.Append(Environment.NewLine);
        }

        public void AutoTabLine(string pLine)
        {
            AutoTab(pLine);
            writeNewLine();
            
        }

        public void AutoTab(string pLine)
        {
            for (int i = 1; i < _tabLevel; i++)
            {
                buffer.Append("\t");
            }
            buffer.Append(pLine);
        }

        public void IncreaseTab()
        {
            _tabLevel++;
        }

        public void DecreaseTab()
        {
            _tabLevel--;
        }

        public void writeLine(string pLine)
        {
            write(pLine);
            writeNewLine();
        }

        public void write(string pLine)
        {
            buffer.Append(pLine);
        }

        private string findDirectoryNameFromFileName(string pFileName)
        {
            return new FileInfo(pFileName).Directory.FullName;
        }

        public void Save(string pFileName, bool pIfExistsOverride)
        {
            string directoryName = findDirectoryNameFromFileName(pFileName);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            if (pIfExistsOverride)
            {
                File.WriteAllText(pFileName, buffer.ToString(),Encoding.UTF8);
            }
            else
            {
                if (!File.Exists(pFileName))
                {
                    File.WriteAllText(pFileName, buffer.ToString());
                }
            }
        }

        public void SaveEncoding(string outputFullFileNameGenerated, string pOption, string pEncoding)
        {
            if (pOption == "o")
            {
                Save(outputFullFileNameGenerated, true);
            }
            else
            {
                Save(outputFullFileNameGenerated, false);
            }
        }

        public void Clear()
        {
            buffer = new StringBuilder(1000);
        }


        public override string ToString()
        {
            return buffer.ToString();
        }

    }
}
