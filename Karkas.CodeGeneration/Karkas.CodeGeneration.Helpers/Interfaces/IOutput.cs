using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGeneration.Helpers.Interfaces
{
    public interface IOutput
    {


        int tabLevel { get; set; }

        void autoTabLn(string p);

        void autoTab(string p);

        void increaseTab();

        void decreaseTab();

        void writeLine(string p);

        void Save(string p, bool p_2);

        void Clear();


        void SaveEncoding(string outputFullFileNameGenerated, string p, string p_2);


        void write(string p);
    }
}
