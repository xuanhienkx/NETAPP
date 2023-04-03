using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using SMS.Common.Configuration;

namespace SMS.Common.Action
{
    public class SendEsmsAction : AbstractAction, IDisposable
    {
        private readonly ILogger logger;
        protected EsmsTemplateConfiguration Template;
        private string _executeResult;
        protected HttpClient NetClient;

        public SendEsmsAction(ILogger logger)
        {
            if (logger == null) throw new ArgumentNullException("logger");
            this.logger = logger;
          
        }

        /// <summary>
        /// Use this to add an specific reciever, and not to include the reciever from the XML file.
        /// </summary>
        public string OverrideReceiver { get; set; }
         
        public override void Execute(object sender, EventArgs e)
        { 
            if (IsFormatSmslReady(sender))
            {
                _executeResult = PostSendAsync();
            }
        }

        public override void Init(string actionName, string initializedValue, XmlElement settings)
        {
            Template = ApiEmsConfiguration.Current.Templates.FirstOrDefault(x => x.Name == initializedValue);
            NetClient = new HttpClient
            {
                BaseAddress = new Uri(Template.Url),
                Timeout = TimeSpan.FromSeconds(ApiEmsConfiguration.Current.ResponseTimeOut) 
            };
        }

        public override string ExecuteResult(object sender, EventArgs arg)
        {
            if (IsFormatSmslReady(sender))
            {
                return _executeResult;
            }
            return string.Empty;
        }

        const string XmlResult = "<SmsResultModel><CodeResult><%=CodeResult%></CodeResult><ErrorMessage><%=ErrorMessage%></ErrorMessage><SMSID><%=SmsId%></SMSID></SmsResultModel>";
        private string PostSendAsync()
        {
            string resultXml;
            try
            {

                var message = OverrideReceiver.Trim();
                var response = NetClient.PostAsync(NetClient.BaseAddress, new StringContent(message)).Result; 
                response.EnsureSuccessStatusCode();
                resultXml = response.Content.ReadAsStringAsync().Result; 

            }
            catch (WebException ex)
            {
                logger.LogError(ex);
                var resp = ex.Response as HttpWebResponse;
                if (resp == null)
                    throw;
                var result = new Dictionary<string, object>()  
                {
                    {"ErrorMessage" , ex.Message},
                    {"SmsId" , ""},
                    {"CodeResult" , ((int)resp.StatusCode).ToString(CultureInfo.InvariantCulture)}
                };
                resultXml = result.ReplaceText(XmlResult);

            }
            catch (TaskCanceledException ex)
            {
                logger.LogError(ex);
                var result = new Dictionary<string, object>()  
                {
                    {"ErrorMessage" , ex.Message},
                     {"SmsId" , ""},
                    {"CodeResult" ,"TaskCanceledException"}
                };
                resultXml = result.ReplaceText(XmlResult);

            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                var result = new Dictionary<string, object>()  
                {
                    {"ErrorMessage" , ex.Message},
                     {"SmsId" , ""},
                    {"CodeResult" ,"N/A"}
                };
                resultXml = result.ReplaceText(XmlResult);
            }
            return resultXml;
        }
        private bool IsFormatSmslReady(object sender)
        {
            try
            {

                var data = (Dictionary<string, object>)sender; 
                string temMessage = Template.Body.Value.Replace("\r", "").Replace("\n", "").Replace(" ", "");
                var message = data.ReplaceText(temMessage);
                OverrideReceiver = message.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                return false;
            }
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
                NetClient.Dispose();
            }
        }
    }
}