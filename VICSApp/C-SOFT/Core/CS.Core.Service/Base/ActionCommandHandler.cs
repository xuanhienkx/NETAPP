using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Domain;
using CS.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Core.Service.Base
{
    public abstract class ActionCommandHandler<T, TIdentity> : IRequestHandler<ActionCommand<T>, T>, IRequestHandler<DeleteActionCommand<T, TIdentity>, bool>
        where T : IResource<TIdentity>
    {
        protected readonly ICacheService CacheService;
        protected readonly IValidationService ValidationService;

        protected ActionCommandHandler(IValidationService validationService, ICacheService cacheService)
        {
            this.CacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            this.ValidationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
        }

        public abstract bool UseCache { get; }

        public async Task<T> Handle(ActionCommand<T> message, CancellationToken cancellationToken)
        {
            if (!ValidationService.Validate(message.Model, message.Validator))
                return message.Model;

            return await CacheService.Set<TIdentity, T>(
                () => UseCache,
                () => message.Type == ActionType.Insert
                    ? Insert(message.Model)
                    : Update(message.Model));
        }

        public async Task<bool> Handle(DeleteActionCommand<T, TIdentity> message, CancellationToken cancellationToken)
        {
            if (!ValidationService.Validate(message))
                return false;

            var isDeleted =await Delete(message.Id);

            await CacheService.Remove<TIdentity, T>(() => isDeleted && UseCache, message.Id);

            return isDeleted;
        }

        protected abstract Task<bool> Delete(TIdentity messageId);
        protected abstract Task<T> Update(T model);
        protected abstract Task<T> Insert(T model);
    }
}