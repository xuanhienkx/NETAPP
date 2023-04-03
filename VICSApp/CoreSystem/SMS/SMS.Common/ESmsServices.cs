using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using SMS.Common.Configuration;
using SMS.Common.Models;

namespace SMS.Common
{
    public static class ESmsServices
    {
        public const string OnPostSendBrandName = "OnPostSendBrandName";
        public const string OnPostSendNormal = "OnPostSendNormal";
        public const string OnGetStatus = "OnGetStatus";
        public const string OnGetStatusBrandName = "OnGetStatusBrandName";

        #region Process Send SMS
        public static async Task<SmsResultModel> SendMessageAsync(string name, object smsOptions)
        {
            var options = smsOptions.GetType()
                .GetProperties()
                .ToDictionary(x => x.Name, x => x.GetValue(smsOptions, null));
            return await SendMessageAsync(name, options);
        }
        public static async Task<SmsResultModel> SendMessageAsync(string name, IDictionary<string, object> smsOptions)
        {
            return await Task.Run(() => SendMessage(name, smsOptions));
        }

        public static SmsResultModel SendMessage(string name, object smsOptions)
        {
            var options = smsOptions.GetType()
                .GetProperties()
                .ToDictionary(x => x.Name, x => x.GetValue(smsOptions, null));
            return SendMessage(name, options);
        }

        public static SmsResultModel SendMessage(string name, IDictionary<string, object> smsOptions)
        {
            EventManager.Trigger(name, smsOptions);
            var test = EventManager.ResultTaget;
            var result = Helpers.Xml2Obj<SmsResultModel>(test);
            return result;
        }

        public static SmsStatus GetStausMessage(string name, object smsOptions)
        {

            var options = smsOptions.GetType()
                .GetProperties()
                .ToDictionary(x => x.Name, x => x.GetValue(smsOptions, null));
            return GetStausMessage(name, options);
        }

        public static SmsStatus GetStausMessage(string name, IDictionary<string, object> smsOptions)
        {
            EventManager.Trigger(name, smsOptions);
            var test = EventManager.ResultTaget;
            var result = Helpers.Xml2Obj<SmsStatus>(test);
            return result;
        }

        public static SmsReceiver GetReceiverMessage(string name, object smsOptions)
        {

            var options = smsOptions.GetType()
                .GetProperties()
                .ToDictionary(x => x.Name, x => x.GetValue(smsOptions, null));
            return GetReceiverMessage(name, options);
        }
        public static SmsReceiver GetReceiverMessage(string name, IDictionary<string, object> smsOptions)
        {
            EventManager.Trigger(name, smsOptions);
            var test = EventManager.ResultTaget;
            var smsReceiver = Helpers.Xml2Obj<SmsReceiver>(test);
            return smsReceiver;
        }



        #endregion


    }
}