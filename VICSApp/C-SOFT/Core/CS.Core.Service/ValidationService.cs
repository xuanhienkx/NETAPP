using CS.Common.Domain.Interfaces;
using CS.Core.Service.Base;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;

namespace CS.Core.Service
{
    public class ValidationService : IValidationService
    {
        private readonly ILogger<ValidationService> logger;
        private readonly IValidatorFactory validatorFactory;
        private readonly IDomainDataHandler domainDataHandler;

        public ValidationService(IValidatorFactory validatorFactory, IDomainDataHandler domainDataHandler, ILogger<ValidationService> logger)
        {
            this.domainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.validatorFactory = validatorFactory ?? throw new ArgumentNullException(nameof(validatorFactory));
        }

        public bool Validate<T>(T message)
        {
            var validator = validatorFactory.GetValidator<T>();
            return Validate(message, validator);
        }

        public bool Validate<T>(T model, IValidator<T> validator)
        {
            if (validator == null)
                return true;

            logger.LogDebug("Validate {0} with validator {1}", model.GetType().Name, validator.GetType().Name);

            // set to stop on failure
            var validationResult = validator.Validate(model);
            if (validationResult.IsValid)
                return true;

            foreach (var error in validationResult.Errors)
            {
                domainDataHandler.RaiseError(error.ErrorMessage);
            }
            return false;
        }
    }
}