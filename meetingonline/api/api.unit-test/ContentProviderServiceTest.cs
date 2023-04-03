//using System;
//using System.IO;
//using api.common.Shared;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using Xunit;

//namespace api.unit_test
//{
//    public class ContentProviderServiceTest
//    {
//        [Fact]
//        public void LoadEmailTemplate()
//        {
//            using var file = File.OpenText(".data/email-template.vi.json");
//            using var reader = new JsonTextReader(file);
//            var jObj = (JObject)JToken.ReadFrom(reader);
//            var value = jObj.GetValue("register").ToObject<EmailContent>();
//        }
//    }
//}
