using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Api.Data
{
    public class DataMaterializer<T>
    {
        private readonly DataShaper<T> shaper;

        public DataMaterializer(DataShaper<T> shaper)
        {
            this.shaper = shaper ?? throw new ArgumentNullException(nameof(shaper));
        }

        public IList<T> Materialize(DbCommand command)
        {
            return Materialize(command.ExecuteReader());
        }

        public IList<T> Materialize(DbDataReader reader)
        {
            var result = new List<T>();

            while (reader.Read())
            {
                result.Add(shaper.Shaper(reader));
            }

            return result;
        }
    }
}
