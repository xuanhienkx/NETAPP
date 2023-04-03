using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Common.Interfaces
{
    public interface IDbInitializer
    {
        Task Initialize(IServiceProvider serviceProvider);
        string Name { get; }
    }
}
