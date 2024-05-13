using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        public CategoryController(SiteProvider provider) : base(provider)
        {
        }

        public IEnumerable<object> GetCategories()
        {
            List<Category> list = provider.Category.GetCategories();

            IEnumerable<object> objects = list.Select(p => new
            {
                p.Id,
                p.Name,
                Children = p.Children.Select(q=> new { q.Id, q.Name })
            });
            return objects;
            
        }
        //public string Welcome(){
        //    return "Welcome Ladies and Gentlemen";
        //}
    }
}