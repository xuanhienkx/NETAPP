using CS.Common;
using CS.Common.Std;
using CS.Common.Std.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace CS.SwiftParser.Configuration
{
    public interface IFieldConfigurator
    {
        IList<Field> this[string id] { get; set; }
        string BussinessIdByRef(string referenceId);
    }

    public class FieldConfigurator : IFieldConfigurator
    {
        private readonly string pendingPath;
        private readonly IDictionary<string, IList<Field>> fields;
        private readonly string vsdSettingPath;
        public FieldConfigurator(IConfigurationRoot configuration)
        {
            vsdSettingPath = configuration?["gateway:settingPath"] ?? throw new ArgumentNullException(nameof(configuration));
            pendingPath = configuration["gateway:pendingPath"];
            fields = new Dictionary<string, IList<Field>>();
        }

        /// <summary>
        /// Id contains the message type, id, sub-message type, propietary and purpose of the message.
        /// They diliminated by _
        /// For example: MT_589_001_Normal_Request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<Field> this[string id]
        {
            set => fields[id] = value;
            get
            {
                if (fields.ContainsKey(id))
                    return fields[id];

                var file = Path.Combine(vsdSettingPath, "Messages", $"{id}.json");
                var tmp = ObjectLoader.FromFile<IList<Field>>(file);
                fields[id] = tmp;
                return tmp;
            }
        }

        public string BussinessIdByRef(string referenceId)
        {    
            var pendingFile = Path.Combine(pendingPath, $"{referenceId}.dat");
            var content = ObjectLoader.FromFile<IDictionary<string, object>>(pendingFile);
            return content[BusinessIdProviderConstant.BusinessId].ToString();
        }
    }
}
