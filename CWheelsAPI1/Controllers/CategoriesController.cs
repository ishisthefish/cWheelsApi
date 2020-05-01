using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWheelsAPI1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CWheelsAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private CWheelsDbContext _cWheelsDbContext;
        public CategoriesController(CWheelsDbContext cWheelsDbContext)
        {
            _cWheelsDbContext = cWheelsDbContext;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var categories = _cWheelsDbContext.Categories;
            return Ok(categories);
        }
    }

}