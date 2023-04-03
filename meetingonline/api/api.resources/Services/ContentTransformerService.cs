using api.common.Shared;
using api.common.Shared.Interfaces;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.IO.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Font;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Path = System.IO.Path;

namespace api.resources.Services
{
    public class ContentTransformerService : IContentTransformerService
    {
        private readonly string pathTemplate = ".data/ReportTemplate";

        private readonly ILogger<ContentProviderService> logger;

        public ContentTransformerService(ILogger<ContentProviderService> logger, IFileService fileService)
        {
            if (fileService == null) throw new ArgumentNullException(nameof(fileService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.pathTemplate = fileService.GetPath(pathTemplate);
        }
        public string Transform(string html, PlaceHolder rep)
        {

            if (rep == null)
            {
                return html;
            }

            // Replace images barCode or qrCode
            foreach (var replace in rep.ImagePlaceHolders)
            {
                html = html.Replace(rep.ImagePlaceHolderStartTag + replace.Key + rep.ImagePlaceHolderEndTag,
                    "<img class='qrCode' src=\"data:image/png;base64," +
                    Convert.ToBase64String(replace.Value.ImageBytes) + "\"/>");
            }

            /*
             * Replace Texts
             */
            html = rep.TextPlaceHolders.Aggregate(html,
                (current, trDict) =>
                    current.Replace(rep.TextPlaceHolderStartTag + trDict.Key + rep.TextPlaceHolderEndTag,
                        trDict.Value));


            foreach (var table in rep.TablePlaceHolders) //Take a Row/Table (one Dictionary) at a time
            {
                //This is the first PlaceHolder in the row, so the first columns. We'll need 
                var tableCol0 = table.First();

                //just that one to find a matching table col
                // Find the first text element matching the search string - Then we will find the row -
                // where the text (PlaceHolder) is inside a table cell --> this is the row we are searching for.
                var placeHolder = string.Concat(rep.TablePlaceHolderStartTag, tableCol0.Key, rep.TablePlaceHolderEndTag);

                var regex = new Regex("<tr((?!<tr)[\\s\\S])*" + placeHolder + "[\\s\\S]*?</tr>");
                var match = regex.Match(html);

                //Now we have the correct table and the row containing the PlaceHolder
                if (match.Success)
                {
                    var copiedRow = match.Value;
                    var differenceInNoCharacters = 0;
                    //Lets create new row by new row and replace PlaceHolder
                    for (var newRow = 0; newRow < tableCol0.Value.Length; newRow++)
                    {
                        //Now cycle through the "columns" (keys) of the Dictionary and replace item by item
                        for (var tableCol = 0; tableCol < table.Count; tableCol++)
                        {
                            var colPlaceHolder = table.ElementAt(tableCol);
                            var currentKey = string.Concat(rep.TablePlaceHolderStartTag, colPlaceHolder.Key,
                                rep.TablePlaceHolderEndTag);

                            if (html.Contains(currentKey))
                            {
                                var oldHtml = html;
                                html = html.Replace(currentKey,
                                    colPlaceHolder.Value[newRow]);
                                differenceInNoCharacters += html.Length - oldHtml.Length;
                            }

                        }

                        //If we have not reached the end of the rows to insert, we 
                        //can insert the resulting row
                        if (newRow < tableCol0.Value.Length - 1)
                        {
                            html = html.Insert(
                                (match.Index + ((newRow + 1) * match.Length) + differenceInNoCharacters),
                                copiedRow);
                        }

                        html = html.Replace(rep.NewLineTag, "<br>");
                    }
                }
            }

            return html;
        }

        public async Task TransformHtmlToPdf(string fileName, string html)
        {
            logger.LogDebug($"fileName==> {fileName}");
            var properties = new ConverterProperties();
            FontProvider fontProvider = new DefaultFontProvider(false, false, false);
            foreach (var font in FileConfiguration.Fonts)
            {
                var pathFont = Path.Combine(pathTemplate, "Open_Sans", font);
                logger.LogDebug($"pathFont==> {pathFont}");
                var fontProgram = FontProgramFactory.CreateFont(pathFont);
                logger.LogDebug($"fontProgram==> {JsonConvert.SerializeObject(fontProgram)}");
                fontProvider.AddFont(fontProgram);
            }

            properties.SetFontProvider(fontProvider);
            var writer = new PdfWriter(fileName);
            var pdf = new PdfDocument(writer);
            pdf.SetTagged();
            pdf.SetDefaultPageSize(PageSize.A4);

            await using var htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(html));
            HtmlConverter.ConvertToPdf(htmlStream, pdf, properties);
        }

        public ImageElement TransformToQRCode(string content)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var bitmap = qrCode.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.White, true);
            using var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            return new ImageElement
            {
                ImageBytes = stream.ToArray(),
                Dpi = 20
            };
        }
    }
}
