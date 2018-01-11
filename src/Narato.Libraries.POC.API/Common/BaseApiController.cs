using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Narato.Libraries.POC.Application.Common;

namespace Narato.Libraries.POC.API.Common
{
    public class BaseApiController : Controller
    {
        protected async Task<TResponse> HandleUseCase<TRequest, TResponse>(TRequest request)
        {
            var usecase = (IUseCases<TRequest, TResponse>)HttpContext.RequestServices.GetService(typeof(IUseCases<TRequest, TResponse>));

            return await usecase.Execute(request);
        }
    }
}
