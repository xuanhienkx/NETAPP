using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Api.Data
{
    public abstract class DataShaper<T>
    {
        protected DataShaper(Func<IDataRecord, T> shaper)
        {
            this.Shaper = shaper ?? throw new ArgumentNullException(nameof(shaper));
        }

        public Func<IDataRecord, T> Shaper { get; }
    }
}
