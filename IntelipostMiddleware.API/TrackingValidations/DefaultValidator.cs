using IntelipostMiddleware.API.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IntelipostMiddleware.API.TrackingValidations
{
    /// <summary>
    /// Validaçoes customizadas podem ser feitas extendendo essa classe
    /// </summary>
    public abstract class DefaultValidator<T> : IValidator
    {
        protected T data;
        protected ModelStateDictionary dictionary;
        public DefaultValidator(T data, ModelStateDictionary dictionary)
        {
            this.data = data;
            this.dictionary = dictionary;
        }

        public abstract bool IsValid();
    }
}
