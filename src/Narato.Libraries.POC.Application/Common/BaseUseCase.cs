using System.Threading.Tasks;

namespace Narato.Libraries.POC.Application.Common
{
    public abstract class BaseUseCase<TRequest, TResponse> : IUseCases<TRequest, TResponse>
    {

        public abstract Task<TResponse> Execute(TRequest request);

    }
}