using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGeneration.Helpers.Interfaces;

namespace Karkas.CodeGeneration.Helpers.BaseClasses
{
    public abstract class BaseGenerator
    {
        protected void AtStartCurlyBraceletIncreaseTab(IOutput output)
        {
            output.autoTabLn("{");
            output.increaseTab();
        }
        protected void AtEndCurlyBraceletDescreaseTab(IOutput output)
        {
            output.decreaseTab();
            output.autoTabLn("}");
        }
        protected void AtStartCurlyBracelet(IOutput output)
        {
            output.autoTabLn("{");
        }
        protected void AtEndCurlyBracelet(IOutput output)
        {
            output.autoTabLn("}");
        }


    }
}

