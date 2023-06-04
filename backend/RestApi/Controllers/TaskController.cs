using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ManagerDbContext _db;

        public TaskController(ManagerDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] ToDoTask task)
        {
            _db.Add(task);
            _db.SaveChanges();

            return Ok(task);
        }

        [HttpGet("{elementId}")]
        public IActionResult GetTasks(int elementId)
        {
            ToDoTask task = _db.Tasks.Find(elementId);

           if (task == null)
           {
                return NotFound();
           }

           return Ok(task);
        }
    }
}
