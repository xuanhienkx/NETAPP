using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Core.Service.Base;

public interface IValidationService
{
    bool Validate<T>(T message);
    bool Validate<T>(T model, IValidator<T> validator);
}