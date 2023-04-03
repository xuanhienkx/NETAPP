using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace api.common.Shared.Interfaces
{
    public interface IContentTransformerService
    {
        string Transform(string html, PlaceHolder placeHolder);

        Task TransformHtmlToPdf(string fileName, string html);
        ImageElement TransformToQRCode(string content);
    }
}
