using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGeneration.Helpers.Interfaces
{
    public interface IOutput
    {


        int TabLevel { get; set; }

        void AutoTabLine(string p);

        void AutoTab(string p);

        void IncreaseTab();

        void DecreaseTab();

        void writeLine(string p);

        void Save(string p, bool p_2);

        void Clear();


        void SaveEncoding(string outputFullFileNameGenerated, string p, string p_2);


        void Write(string p);
    }
}
