using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApplication.Application.Exceptions;
using WebApplication.Application.Validator;

namespace WebApplication.Application.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly RequestValidatorFactory _requestValidatorFactory;

        public ValidatorBehavior(RequestValidatorFactory requestValidatorFactory)
        {
            _requestValidatorFactory = requestValidatorFactory;
        }

        public async Task<TResponse> Handle(
            TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validator = _requestValidatorFactory.GetRequestValidator<TRequest>();
            var validResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validResult.IsValid)
            {
                throw new RequestInvalidException("");
            }

            return await next();
        }
    }
}