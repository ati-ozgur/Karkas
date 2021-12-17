namespace Karkas.Web.Helpers
{
    using System;
    using System.Drawing;
    using System.Drawing.Printing;

    public class PrinterControl
    {
        protected string icerik = null;
        protected Font printFont;

        private void doc_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
        }

        private void PagePrint(object sender, PrintPageEventArgs e)
        {
            float linesPerPage = 0f;
            float linePosition = 0f;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            linesPerPage = ((float) e.MarginBounds.Height) / this.printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(this.icerik, this.printFont, Brushes.Black, leftMargin, linePosition, new StringFormat());
            if (this.icerik != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        public void Yazdir(string printerName, string pageTitle, string icerik)
        {
            this.icerik = icerik;
            this.printFont = new Font("Arial", 12f);
            PrintDocument doc = new PrintDocument();
            doc.PrinterSettings.PrinterName = printerName;
            doc.QueryPageSettings += new QueryPageSettingsEventHandler(this.doc_QueryPageSettings);
            doc.PrintPage += new PrintPageEventHandler(this.PagePrint);
            doc.Print();
        }
    }
}


