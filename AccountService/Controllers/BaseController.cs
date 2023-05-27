using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator? Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? mediator;
    }
}
