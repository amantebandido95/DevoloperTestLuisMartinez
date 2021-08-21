using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using CovidCasesReports.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CovidCasesReports.Utils
{
    public class PdfMaker
    {
        public byte[] GenerateRegionPDF(List<SimpleRegionReport> _Regions)
        {
            byte[] file;
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);

                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                Phrase phrase = new Phrase("TOP TEN COVID CASES", new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.BLACK));

                Paragraph para = new Paragraph();
                para.Add(phrase);
                para.Alignment = Element.ALIGN_CENTER;

                document.Add(para);

                Phrase phraseEmpty = new Phrase(" ");
                document.Add(phraseEmpty);

                PdfPTable table = new PdfPTable(3);

                #region Header
                PdfPCell cellRegion = new PdfPCell(new Phrase("Region", new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.WHITE)));
                cellRegion.BackgroundColor = new BaseColor(12, 111, 118);
                cellRegion.BorderWidthBottom = 1f;
                cellRegion.BorderWidthTop = 1f;
                cellRegion.PaddingBottom = 10f;
                cellRegion.PaddingLeft = 20f;
                cellRegion.PaddingTop = 4f;
                table.AddCell(cellRegion);

                PdfPCell cellCases = new PdfPCell(new Phrase("Cases", new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.WHITE)));
                cellCases.BackgroundColor = new BaseColor(12, 111, 118);
                cellCases.HorizontalAlignment = Element.ALIGN_CENTER;
                cellCases.BorderWidthBottom = 1f;
                cellCases.BorderWidthTop = 1f;
                cellCases.PaddingBottom = 10f;
                cellCases.PaddingTop = 4f;
                table.AddCell(cellCases);

                PdfPCell cellDeaths = new PdfPCell(new Phrase("Deaths", new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.WHITE)));
                cellDeaths.BackgroundColor = new BaseColor(12, 111, 118);
                cellDeaths.HorizontalAlignment = Element.ALIGN_CENTER;
                cellDeaths.BorderWidthBottom = 1f;
                cellDeaths.BorderWidthTop = 1f;
                cellDeaths.PaddingBottom = 10f;
                cellDeaths.PaddingTop = 4f;
                table.AddCell(cellDeaths);

                #endregion

                #region Table Body
                foreach (SimpleRegionReport region in _Regions)
                {

                    PdfPCell cellRegion1 = new PdfPCell(new Phrase(region.regionName, new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.BLACK)));
                    table.AddCell(cellRegion1);

                    PdfPCell cellCases1 = new PdfPCell(new Phrase(String.Format("{0:n0}", region.cases), new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.BLACK)));
                    cellCases1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cellCases1);

                    PdfPCell cellDeaths1 = new PdfPCell(new Phrase(String.Format("{0:n0}", region.deaths), new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.BLACK)));
                    cellDeaths1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cellDeaths1);

                }

                #endregion

                document.Add(table);

                Phrase phraseGenerated = new Phrase("This report was generated on: " + System.DateTime.Now.ToString(), new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.BLACK));

                Paragraph paraGenerated = new Paragraph();
                paraGenerated.Add(phraseGenerated);
                paraGenerated.Alignment = Element.ALIGN_CENTER;

                document.Add(paraGenerated);

                document.Close();

                file = memoryStream.ToArray();

                return file;
            }

        }

        public byte[] GenerateProvincesPDF(List<SimpleProvinceReport> _Provinces, string iso)
        {
            byte[] file;
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);

                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                Phrase phrase = new Phrase("TOP TEN COVID CASES", new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.BLACK));

                Paragraph para = new Paragraph();
                para.Add(phrase);
                para.Alignment = Element.ALIGN_CENTER;

                document.Add(para);

                Phrase phraseEmpty = new Phrase(" ");
                document.Add(phraseEmpty);

                PdfPTable table = new PdfPTable(3);

                #region Header
                PdfPCell cellRegion = new PdfPCell(new Phrase("Provinces of " + iso, new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.WHITE)));
                cellRegion.BackgroundColor = new BaseColor(12, 111, 118);
                cellRegion.BorderWidthBottom = 1f;
                cellRegion.BorderWidthTop = 1f;
                cellRegion.PaddingBottom = 10f;
                cellRegion.PaddingLeft = 20f;
                cellRegion.PaddingTop = 4f;
                table.AddCell(cellRegion);

                PdfPCell cellCases = new PdfPCell(new Phrase("Cases", new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.WHITE)));
                cellCases.BackgroundColor = new BaseColor(12, 111, 118);
                cellCases.HorizontalAlignment = Element.ALIGN_CENTER;
                cellCases.BorderWidthBottom = 1f;
                cellCases.BorderWidthTop = 1f;
                cellCases.PaddingBottom = 10f;
                cellCases.PaddingTop = 4f;
                table.AddCell(cellCases);

                PdfPCell cellDeaths = new PdfPCell(new Phrase("Deaths", new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.WHITE)));
                cellDeaths.BackgroundColor = new BaseColor(12, 111, 118);
                cellDeaths.HorizontalAlignment = Element.ALIGN_CENTER;
                cellDeaths.BorderWidthBottom = 1f;
                cellDeaths.BorderWidthTop = 1f;
                cellDeaths.PaddingBottom = 10f;
                cellDeaths.PaddingTop = 4f;
                table.AddCell(cellDeaths);

                #endregion

                #region Table Body
                foreach (SimpleProvinceReport provinces in _Provinces)
                {

                    PdfPCell cellRegion1 = new PdfPCell(new Phrase(provinces.provinceName, new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.BLACK)));
                    table.AddCell(cellRegion1);

                    PdfPCell cellCases1 = new PdfPCell(new Phrase(String.Format("{0:n0}", provinces.cases), new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.BLACK)));
                    cellCases1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cellCases1);

                    PdfPCell cellDeaths1 = new PdfPCell(new Phrase(String.Format("{0:n0}", provinces.deaths), new Font(Font.FontFamily.HELVETICA, 18f, Font.NORMAL, BaseColor.BLACK)));
                    cellDeaths1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cellDeaths1);

                }

                #endregion

                document.Add(table);

                Phrase phraseGenerated = new Phrase("This report was generated on: " + System.DateTime.Now.ToString(), new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.BLACK));

                Paragraph paraGenerated = new Paragraph();
                paraGenerated.Add(phraseGenerated);
                paraGenerated.Alignment = Element.ALIGN_CENTER;

                document.Add(paraGenerated);

                document.Close();

                file = memoryStream.ToArray();

                return file;
            }

        }

    }
}
