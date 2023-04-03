using Serilog.Core;
using Serilog.Events;

namespace DSoft.InforGateway.Helpers
{
    class SimpleClassEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var typeName = logEvent.Properties.GetValueOrDefault("SourceContext").ToString();
            var pos = typeName.LastIndexOf('.');
            typeName = typeName.Substring(pos + 1, typeName.Length - pos - 2);
            logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("SourceContext", typeName));
        }
    }
}
