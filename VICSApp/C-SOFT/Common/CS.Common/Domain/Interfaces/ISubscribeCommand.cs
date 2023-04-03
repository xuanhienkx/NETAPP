using System.Collections.Generic;
using CS.Common.Enums;

namespace CS.Common.Domain.Interfaces
{
    public interface ISubscribeCommand
    {
        IList<MessageQueueType> InformTypes { get; }
    }
}
