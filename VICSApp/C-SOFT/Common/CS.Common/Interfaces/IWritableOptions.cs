using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace CS.Common.Interfaces
{
    public interface IWritableOptions<out T> : IOptionsSnapshot<T> where T : class, new()
    {
        void Update(Action<T> applyChanges);
    }
}
