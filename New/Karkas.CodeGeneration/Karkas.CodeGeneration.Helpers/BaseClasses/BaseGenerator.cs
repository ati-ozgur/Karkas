using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGenerationHelper.BaseClasses
{
    public abstract class BaseGenerator
    {
        protected void BaslangicSusluParentezVeTabArtir(IOutput output)
        {
            output.autoTabLn("{");
            output.increaseTab();
        }
        protected void BitisSusluParentezVeTabAzalt(IOutput output)
        {
            output.decreaseTab();
            output.autoTabLn("}");
        }
        protected void BaslangicSusluParentez(IOutput output)
        {
            output.autoTabLn("{");
            output.increaseTab();
        }
        protected void BitisSusluParentez(IOutput output)
        {
            output.decreaseTab();
            output.autoTabLn("}");
        }


    }
}

