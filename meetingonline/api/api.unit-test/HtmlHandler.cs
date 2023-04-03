using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions; 

namespace api.unit_test
{
    public class HtmlHandler
    {
        public static string ReplaceAll(string html, Placeholders rep)
        {

            if (rep == null)
            {
                return html;
            }

            /*
             * Replace Texts
             */
            foreach (var trDict in rep.TextPlaceholders)
            {
                html = html.Replace(rep.TextPlaceholderStartTag + trDict.Key + rep.TextPlaceholderEndTag,
                    trDict.Value);
            }

            /*
             * Replace images
             */
//            foreach (var replace in _rep.ImagePlaceholders)
//            {
//                html = html.Replace(_rep.ImagePlaceholderStartTag + replace.Key + _rep.ImagePlaceholderEndTag,
//                    "<img src=\"data:image/" + ImageHandler.GetImageTypeFromMemStream(replace.Value.memStream) + ";base64," +
//                    ImageHandler.GetBase64FromMemStream(replace.Value.memStream) + "\"/>");
//            }

            /*
             * Replace Tables
             */
            foreach (var table in rep.TablePlaceholders) //Take a Row/Table (one Dictionary) at a time
            {

                var tableCol0 = table.First(); //This is the first placeholder in the row, so the first columns. We'll need 
                //just that one to find a matching table col
                // Find the first text element matching the search string - Then we will find the row -
                // where the text (placeholder) is inside a table cell --> this is the row we are searching for.
                var placeholder = rep.TablePlaceholderStartTag + tableCol0.Key + rep.TablePlaceholderEndTag;

                var regex = new Regex("<tr((?!<tr)[\\s\\S])*" + placeholder + "[\\s\\S]*?</tr>");
                var match = regex.Match(html);
                if (match.Success) //Now we have the correct table and the row containing the placeholders
                {
                    string copiedRow = match.Value;
                    var laenge = copiedRow.Length;
                    int differenceInNoCharacters = 0;

                    for (var newRow = 0; newRow < tableCol0.Value.Length; newRow++) //Lets create new row by new row and replace placeholders
                    {
                        for (var tableCol = 0;
                            tableCol < table.Count;
                            tableCol++) //Now cycle through the "columns" (keys) of the Dictionary and replace item by item
                        {
                            var colPlaceholder = table.ElementAt(tableCol);

                            if (html.Contains(rep.TablePlaceholderStartTag + colPlaceholder.Key + rep.TablePlaceholderEndTag))
                            {
                                var oldHtml = html;
                                html = html.Replace(
                                    rep.TablePlaceholderStartTag + colPlaceholder.Key + rep.TablePlaceholderEndTag,
                                    colPlaceholder.Value[newRow]);
                                differenceInNoCharacters += html.Length - oldHtml.Length;
                            }
                        }





                        if (newRow < tableCol0.Value.Length - 1)//If we have not reached the end of the rows to insert, we 
                        //can insert the resulting row
                        {
                            html = html.Insert((match.Index + ((newRow + 1) * match.Length) + differenceInNoCharacters), copiedRow);

                        }

                    }

                    html = html.Replace(rep.NewLineTag, "<br>");

                }


            }

            return html;
        }


    }
}