using System.Threading.Tasks;

namespace Narato.Libraries.POC.Application.Common
{
    public interface IUseCases<TRequest, TResponse>
    {
        Task<TResponse> Execute(TRequest request);
    }
}