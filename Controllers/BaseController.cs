using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class BaseController : Controller
    {
        protected SiteProvider provider;
        public BaseController(SiteProvider provider)
        {
            this.provider = provider;
        }
    }
}
