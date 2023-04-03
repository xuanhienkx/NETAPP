using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using api.domain.Commands;
using iText.Html2pdf;
using iText.Html2pdf.Attach;
using iText.Html2pdf.Attach.Impl;
using iText.Html2pdf.Attach.Impl.Tags;
using iText.Html2pdf.Resolver.Font;
using iText.IO.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Font;
using iText.StyledXmlParser.Css.Media;
using iText.StyledXmlParser.Node;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace api.unit_test
{

    public class ExcelTest
    {
        private readonly ITestOutputHelper testOutputHelper;
        public ExcelTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }
      
        [Fact]
        public void ReadExeclTest()
        {
            var obj = ReadExcel.ReadExcelToList<MeetingHolderCreateCommand>();
            testOutputHelper.WriteLine(JsonConvert.SerializeObject(obj));
        }


        [Theory]
        [InlineData("html-vote-template")]
        public void Html2PdfTest(string name)
        {
            //            using (FileStream htmlSource = File.Open($".data/{name}.html", FileMode.Open))
            //            using (FileStream pdfDest = File.Open($".data/{name}-{DateTime.Now.Ticks.ToString()}.pdf", FileMode.OpenOrCreate))
            //            {
            //                ConverterProperties converterProperties = new ConverterProperties(); 
            //                HtmlConverter.ConvertToPdf(htmlSource, pdfDest, converterProperties);
            //            }
            var src = $".data/{name}.html";
            var dest = $"D:/report/{name}-{DateTime.Now.Ticks}.pdf";
            //  HtmlConverter.ConvertToPdf(new FileStream(src, FileMode.Open), new FileStream(dest, FileMode.Create));

            ConverterProperties properties = new ConverterProperties();
            FontProvider fontProvider = new DefaultFontProvider(false, false, false);
//            foreach (string font in Fonts)
//            {
//                FontProgram fontProgram = FontProgramFactory.CreateFont(font);
//                fontProvider.AddFont(fontProgram);
//            }

            properties.SetFontProvider(fontProvider);
            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdf = new PdfDocument(writer);
            pdf.SetTagged();
            PageSize pageSize = PageSize.A4;
            pdf.SetDefaultPageSize(pageSize);
            // MediaDeviceDescription mediaDeviceDescription = new MediaDeviceDescription(MediaType.SCREEN);

            // mediaDeviceDescription.SetWidth(pageSize.GetWidth());
            //  properties.SetMediaDeviceDescription(mediaDeviceDescription);

            HtmlConverter.ConvertToPdf(new FileStream(src, FileMode.Open), pdf, properties);
            // Document document = HtmlConverter.ConvertToDocument(new FileStream(src, FileMode.Open), pdf, properties);

            // Document document = new Document(pdf, pageSize);
            //  pdf.AddNewPage();
            //  document.SetMargins(0, 0, 0, 0);
            //  document.Close();
            // HtmlConverter.ConvertToPdf(new FileStream(src, FileMode.Open), pdf, properties);


        } 

    }
}
