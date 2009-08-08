namespace Karkas.Web.Helpers.HelperClasses
{
    using System;

    public interface IMessageBox
    {
        void Close();
        void Show(string pMesaj);
        void Show(string pMesaj, MesajTuruEnum pMesajTuru);
    }
}


