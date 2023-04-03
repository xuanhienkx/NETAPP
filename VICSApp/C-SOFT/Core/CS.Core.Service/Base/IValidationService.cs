using FluentValidation;

namespace CS.Core.Service.Base
{

    public interface IValidationService
    {
        bool Validate<T>(T message);
        bool Validate<T>(T model, IValidator<T> validator);
    }
}
