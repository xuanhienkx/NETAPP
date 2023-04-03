using CS.Common.Contract;
using CS.Common.Contract.Enums;
using FluentValidation;
using MediatR;

namespace CS.Common.Domain
{
    public abstract class ValidableCommand<T, TRequest> : IRequest<TRequest>
    {
        public IValidator<T> Validator;

        protected ValidableCommand(IValidator<T> validator)
        {
            Validator = validator;
        }
    }

    public class ActionCommand<T> : ValidableCommand<T, T>
    {
        public ActionType Type { get; }
        public T Model { get; }

        public ActionCommand(T model, ActionType type, IValidator<T> validator)
            : base(validator)
        {
            Model = model;
            Type = type;
        }
    }

    public class DeleteActionCommand<T, TIdentity> : IRequest<bool> where T : IResource<TIdentity>
    {
        public TIdentity Id { get; }
        public bool IsActive { get; set; }

        public DeleteActionCommand(TIdentity identity)
        {
            Id = identity;
        }
    }

    public class GetCommand<T, TIdentity, TResult> : IRequest<TResult> where T : IResource<TIdentity>
    {
        public TIdentity Id { get; }
        public GetCommand(TIdentity identity)
        {
            Id = identity;
        }
    }

    public class SetCommand<T, TIdentity, TUpdate> : IRequest<bool> where T : IResource<TIdentity>
    {
        public TIdentity Id { get; }
        public TUpdate Updated { get; }

        public SetCommand(TIdentity identity, TUpdate updated)
        {
            Id = identity;
            Updated = updated;
        }
    }
}
