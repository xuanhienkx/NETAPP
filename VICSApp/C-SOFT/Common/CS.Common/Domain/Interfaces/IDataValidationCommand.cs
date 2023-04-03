using System.ComponentModel.DataAnnotations;

namespace CS.Common.Domain.Interfaces
{
    public interface IDataValidationCommand<in T>
    {
        int Priority { get; }
        bool ForInsert { get; }
        bool ForUpdate { get; }
        bool Validate(T model, out ValidationResult validatioResult);
    }
}
