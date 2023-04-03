using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.common.Shared.Interfaces
{
    public interface IWebSocketService
    {
        Task SendHangfire(string userId, string hfId, string message);
    }
}
