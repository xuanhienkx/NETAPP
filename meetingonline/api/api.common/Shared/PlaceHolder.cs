using System.Collections.Generic;
using System.IO;

namespace api.common.Shared
{
    public class PlaceHolder
    {

        public PlaceHolder()
        {
            this.NewLineTag = "<br/>";
            this.TextPlaceHolderStartTag = "##";
            this.TextPlaceHolderEndTag = "##";
            this.TablePlaceHolderStartTag = "==";
            this.TablePlaceHolderEndTag = "==";
            this.ImagePlaceHolderStartTag = "++";
            this.ImagePlaceHolderEndTag = "++";

            this.TextPlaceHolders = new Dictionary<string, string>();
            this.TablePlaceHolders = new List<Dictionary<string, string[]>>();
            this.ImagePlaceHolders = new Dictionary<string, ImageElement>();
        }

        //NewLineTags are important only for .docx as input. If you use .html as input, then just use "<br
        public string ReportName { get; set; }
        public string ReportTemplateName { get; set; }
        public string NewLineTag { get; set; }

        //Start and End Tags can e. g. be both "##"
        //A PlaceHolder could be ##TextPlaceHolder##
        public string TextPlaceHolderStartTag { get; set; }
        public string TextPlaceHolderEndTag { get; set; }

        public Dictionary<string, string> TextPlaceHolders { get; set; }

        /*
         * For tables it works that way:
         * 1. If you have a table in the word document, create 1 row with a different Dictionary keys
         * Then e. g. you want to have 10 rows in the end, you add 10 values to each array of the Dictionary value
         *
         * A PlaceHolder could be ==TextPlaceHolder==
         */
        //Start and End Tags can e. g. be both "=="

        public string TablePlaceHolderStartTag { get; set; }
        public string TablePlaceHolderEndTag { get; set; }
        public List<Dictionary<string, string[]>> TablePlaceHolders { get; set; }

        /*
         * Important: The MemoryStream may carry an image.
         * Allowed file types: JPEG/JPG, BMP, TIFF, GIF, PNG
         */

        //Take different replacement tags here, else there may be collision with the text replacements,
        //e. g. "++" 
        public string ImagePlaceHolderStartTag { get; set; }
        public string ImagePlaceHolderEndTag { get; set; }

        public Dictionary<string, ImageElement> ImagePlaceHolders { get; set; }
    }

    public class ImageElement
    {
        public byte[] ImageBytes { get; set; }
        public double Dpi { get; set; } // Dots per inch
    }
}