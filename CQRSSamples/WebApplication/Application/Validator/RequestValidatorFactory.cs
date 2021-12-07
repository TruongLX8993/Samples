using System;
using System.Linq;
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication.Application.Validator
{
    public class RequestValidatorFactory
    {
        private readonly Assembly _assembly;

        public RequestValidatorFactory(Assembly assembly)
        {
            _assembly = assembly;
        }

        public IValidator<T> GetRequestValidator<T>()
        {
            var validatorInterfaceType = typeof(IValidator<T>);
            var validatorImplType = _assembly.ExportedTypes
                .FirstOrDefault(t => t.GetInterfaces()
                    .Contains(validatorInterfaceType) && !t.IsInterface);
            return (IValidator<T>)Activator.CreateInstance(validatorImplType);
        }
    }

    public static class RequestValidatorFactoryMiddleware
    {
        public static void AddValidatorFactory(this IServiceCollection serviceCollection, Assembly assembly)
        {
            serviceCollection.AddSingleton(new RequestValidatorFactory(assembly));
        }
    }
}