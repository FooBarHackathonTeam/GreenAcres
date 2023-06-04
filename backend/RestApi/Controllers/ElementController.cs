using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ElementController : ControllerBase
    {
        private readonly ManagerDbContext _db;

        public ElementController(ManagerDbContext db)
        {
            _db = db;
        }

        [HttpGet("{email}")]
        public IActionResult GetElements(string email)
        {
            var elements = _db.Elements
                .Include(e => e.Tasks)
                .Where(e => e.UserId.Equals(email));

            return Ok(elements);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Element element)
        {
            _db.Add(element);
            _db.SaveChanges();

            return Ok(element);
        }

    }
}
