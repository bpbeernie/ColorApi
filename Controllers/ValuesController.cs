using ColourAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ColourAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ColorContext _context;

        public ValuesController(ColorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Color>> GetColorItems()
        {
            return _context.ColorItems;
        }

    }
}
