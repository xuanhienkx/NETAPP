using System;
using System.Collections.Generic;
using System.Text;

namespace api.common.Shared.Interfaces
{
    public interface ILocalizer
    {
        string Get(string key);
        string Get(string key, params object[] arguments);
    }
}
