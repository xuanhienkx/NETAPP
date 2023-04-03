using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using SMS.Common.Configuration;

namespace SMS.Common.Action
{
    public class SendMailAction : AbstractAction, IDisposable
    {
        private readonly ILogger logger;
        protected MailMessage Mail;
        protected EmailTemplateConfiguration Template;

        private static readonly object LockObj = new object();

        public SendMailAction(ILogger logger)
        {
           
            if (logger == null) throw new ArgumentNullException("logger");
            this.logger = logger;
        }

        #region Properties


        /// <summary>
        /// Use this to add an specific reciever, and not to include the reciever from the XML file.
        /// </summary>
        public string OverrideReceiver { get; set; }

        #endregion

        public override void Execute(object sender, EventArgs e)
        {
            lock (LockObj)
            {
                if (IsFormatMailReady(sender))
                    Send(Mail);
            }
        }

        public override void Init(string actionName, string initializedValue, XmlElement settings)
        {
            Template = SmtpConfiguration.Current.Templates.SingleOrDefault(x => x.Name == initializedValue);

            Mail = new MailMessage()
            {
                BodyEncoding = Encoding.UTF8,
                SubjectEncoding = Encoding.UTF8,
                Priority = System.Net.Mail.MailPriority.Normal
            };
        }

        private void Send(MailMessage msg)
        {
            try
            {
                SmtpConfiguration.Current.SmtpClient.Send(msg);
                logger.LogDebug("Sending email succeeded. Subject: " + msg.Subject);
            }
            catch (SmtpException ex)
            {
                logger.LogError(ex);
                throw;
            }
        }

        private bool IsFormatMailReady(object sender)
        {
            if (Template == null)
                return false;

            Mail.To.Clear();
            Mail.CC.Clear();
            Mail.Bcc.Clear();
            Mail.IsBodyHtml = Template.BodyIsHtml;

            var data = (Dictionary<string, object>)sender;
            var body = data.ReplaceText(Template.Body.Value); 
            var view = AlternateView.CreateAlternateViewFromString(body, null, Mail.IsBodyHtml ? MediaTypeNames.Text.Html : MediaTypeNames.Text.Plain);
            var images = new Dictionary<string, string>();

            if (body.IndexOf("<IMG[", StringComparison.OrdinalIgnoreCase) > -1 && body.IndexOf("]IMG>", StringComparison.OrdinalIgnoreCase) > -1)
            {
                var result = "";
                var rest = body;
                while (true)
                {
                    var startIndex = rest.IndexOf("<IMG[", StringComparison.OrdinalIgnoreCase);
                    var startIndex2 = startIndex + 5;
                    var endIndex = rest.IndexOf("]IMG>", StringComparison.OrdinalIgnoreCase);
                    var endIndex2 = endIndex + 5;
                    if ((startIndex >= 0) && (endIndex >= 0) && (endIndex > startIndex))
                    {
                        result += rest.Substring(0, startIndex);
                        var token = rest.Substring(startIndex2, endIndex - startIndex2);

                        // parse format
                        var formatStringStart = token.IndexOf('{');
                        var formatStringEnd = token.IndexOf('}');
                        var formatString = "";
                        if ((formatStringStart != -1) && (formatStringEnd != -1))
                        {
                            formatString = token.Substring(formatStringStart, formatStringEnd - formatStringStart + 1);
                            token = token.Substring(0, formatStringStart);
                        }

                        var id = Guid.NewGuid();
                        images.Add(id.ToString(), token);
                        string val = string.Format(CultureInfo.CurrentCulture, @"<img src=""cid:{0}"" alt=""""/>", id);
                        if (!String.IsNullOrEmpty(formatString))
                        {
                            result += string.Format(CultureInfo.CurrentCulture, formatString, val);
                        }
                        else
                        {
                            result += val;
                        }
                        rest = rest.Substring(endIndex2);
                    }
                    else
                    {
                        result += rest;
                        break;
                    }
                }

                body = result;
                view = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);

                foreach (var key in images.Keys)
                {
                    var imagePath = new System.IO.FileInfo(System.Web.HttpContext.Current.Server.MapPath(images[key])).FullName;
                    var image = new LinkedResource(imagePath) { ContentId = key, ContentType = { Name = imagePath } };
                    view.LinkedResources.Add(image);
                }
            }

            Mail.AlternateViews.Add(view);
            Mail.Body = body;
            var subject = Template.Subject.Value.Replace('\r', ' ').Replace('\n', ' ');
            Mail.Subject = data.ReplaceText(subject);

            var fromAddress = new MailAddress(Template.FromAddress, "MBQ-noreply");
            Mail.Sender = fromAddress;
            Mail.From = fromAddress;

            string[] arrTo = ((string)data["Receiver"]).Replace(" ", "").Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            Mail.To.Add(string.Join(",", arrTo));

            return true;
        }

        // Create an md5 sum string of this string
        static public string GetMd5Sum(string value)
        {
            // First we need to convert the string into bytes, which   
            // means using a text encoder.    
            var enc = Encoding.Unicode.GetEncoder();
            // Create a buffer large enough to hold the string    
            var unicodeText = new byte[value.Length * 2];
            enc.GetBytes(value.ToCharArray(), 0, value.Length, unicodeText, 0, true);
            // Now that we have a byte array we can ask the CSP to hash it    
            MD5 md5 = new MD5CryptoServiceProvider();
            var result = md5.ComputeHash(unicodeText);
            // Build the final string by converting each byte    
            // into hex and appending it to a StringBuilder    
            var sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2", CultureInfo.CurrentCulture));
            }
            // And return it    
            return sb.ToString();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Mail.Dispose();
            }
        }
    }
}
