using System;
using System.Linq;
using CS.Common.Domain.Interfaces;
using CS.Common.MessageQueue;
using CS.Domain.Data.Entities;

namespace CS.Domain.Data.Repositories
{
    public class MessageQueueSqlRepository : IMessageQueueRepository
    {
        private readonly CSoftDataContext context;

        public MessageQueueSqlRepository(CSoftDataContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Guid Insert<T>(Message<T> message)
        {
            var entity = new MessageQueue
            {
                Id = Guid.NewGuid(),
                Type = message.MessageType,
                CreateDate = message.CreatedDate,
                MessageBody = message.GetMessageBody()
            };
            context.Set<MessageQueue>().AddAsync(entity);
            context.SaveChangesAsync();

            return entity.Id;
        }

        public void Delete(Guid messageQueueId)
        {
            var deleted = context.Set<MessageQueue>().SingleOrDefault(x => x.Id == messageQueueId);
            context.Set<MessageQueue>().Remove(deleted);
            context.SaveChangesAsync();
        }
    }
}
