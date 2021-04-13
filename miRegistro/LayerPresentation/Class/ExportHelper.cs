using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class ExportHelper
{
    public static bool ExportDataGridViewPDF(DataGridView dg, string user)
    {
        bool isOk = false;
        if (dg.Rows.Count > 0)
        {
            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF (*.pdf)|*.pdf";
            sfd.FileName = user + ".pdf";
            bool fileError = false;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfd.FileName))
                {
                    try
                    {
                        File.Delete(sfd.FileName);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }
                }
                if (!fileError)
                {
                    try
                    {
                        Font fontNormal = new Font(Font.FontFamily.TIMES_ROMAN, 8, Font.NORMAL);

                        PdfPTable pdfTable = new PdfPTable(dg.Columns.Count);

                        pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 100;
                        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                        foreach (DataGridViewColumn column in dg.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, fontNormal));
                            cell.BackgroundColor = GrayColor.LIGHT_GRAY;
                            pdfTable.AddCell(cell);
                        }

                        foreach (DataGridViewRow row in dg.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                pdfTable.AddCell(new Phrase(cell.Value.ToString(), fontNormal));
                            }
                        }

                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();
                            pdfDoc.Add(pdfTable);
                            pdfDoc.Close();
                            stream.Close();
                        }

                        if (!fileError) 
                        {
                            isOk = true;
                        }
                        //MessageBox.Show("Data Exported Successfully !!!", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
        }
        else
        {
            MessageBox.Show("No Record To Export !!!", "Info");
        }
        return isOk;
    }
    public static bool ExportDataTablePDF(DataTable dt, string user)
    {
        bool OK = false;
        System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
        sfd.Filter = "PDF (*.pdf)|*.pdf";
        sfd.FileName = user + ".pdf";
        bool fileError = false;
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            if (File.Exists(sfd.FileName))
            {
                try
                {
                    File.Delete(sfd.FileName);
                }
                catch (IOException ex)
                {
                    fileError = true;
                    MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                }
            }
            if (!fileError)
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(sfd.FileName, FileMode.Create));
                document.Open();
                iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);
                Font fontNormal = new Font(Font.FontFamily.TIMES_ROMAN, 8, Font.NORMAL);

                PdfPTable table = new PdfPTable(dt.Columns.Count);
                PdfPRow row = null;
                float[] widths = new float[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                    widths[i] = 4f;

                table.SetWidths(widths);
                table.WidthPercentage = 100;
                table.DefaultCell.Padding = 3;

                int iCol = 0;
                string colname = "";

                PdfPCell cell = new PdfPCell(new Phrase("Tramites"));
                cell.Colspan = dt.Columns.Count;

                foreach (DataColumn c in dt.Columns)
                {
                    PdfPCell ce = new PdfPCell(new Phrase(c.ColumnName, fontNormal));
                    ce.BackgroundColor = GrayColor.LIGHT_GRAY;
                    table.AddCell(ce);
                }

                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int h = 0; h < dt.Columns.Count; h++)
                        {
                            table.AddCell(new Phrase(r[h].ToString(), fontNormal));
                        }
                    }
                }
                document.Add(table);
                document.Close();
                OK = true;
            }
        }
        return OK;
    }
}

