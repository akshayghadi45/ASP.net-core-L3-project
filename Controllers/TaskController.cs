using CoreSkillsApp.Interfaces;
using CoreSkillsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task = CoreSkillsApp.Models.Task;

namespace CoreSkillsApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly IRepository<Task> _repository;

        private readonly ILogger<TasksController> _logger;

        public TasksController(IRepository<Task> repository, ILogger<TasksController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        public IActionResult Index()
        {
            _logger.LogInformation("User accessed task list.");
            var tasks = _repository.GetAll();
            return View(tasks);
                
        }

        public IActionResult Details(int id)
        {
            var task = _repository.GetById(id);
            _logger.LogInformation("User accessed task details for ID {TaskId}", id);
            return task == null ? NotFound() : View(task);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Task task)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Task creation failed due to validation errors.");
                return View(task);
            }

            _repository.Add(task);
            _repository.Save();
            _logger.LogInformation("New task created with ID {TaskId}", task.TaskId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var task = _repository.GetById(id);
            _logger.LogInformation("User accessed task edit for ID {TaskId}", id);
            return task == null ? NotFound() : View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Task task)
        {
            if (id != task.TaskId) return BadRequest();

            if (!ModelState.IsValid) return View(task);

            _repository.Update(task);
            _repository.Save();
            _logger.LogInformation("task edited with ID {TaskId}", task.TaskId);
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var task = _repository.GetById(id);
            _logger.LogInformation("User accessed task delete for ID {TaskId}", id);
            return task == null ? NotFound() : View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            _logger.LogInformation("task deleted");
            return RedirectToAction(nameof(Index));
        }
    }
}



//using CoreSkillsApp.Interfaces;
//using CoreSkillsApp.Models;
//using Microsoft.AspNetCore.Mvc;

//using Task = CoreSkillsApp.Models.Task;

//namespace CoreSkillsApp.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class TasksApiController : ControllerBase
//    {
//        private readonly IRepository<Task> _repository;

//        public TasksApiController(IRepository<Task> repository)
//        {
//            _repository = repository;
//        }

//        // GET: api/tasks
//        [HttpGet]
//        public ActionResult<IEnumerable<Task>> GetAll()
//        {
//            return Ok(_repository.GetAll());
//        }

//        // GET: api/tasks/5
//        [HttpGet("{id}")]
//        public ActionResult<Task> GetById(int id)
//        {
//            var task = _repository.GetById(id);
//            if (task == null) return NotFound();
//            return Ok(task);
//        }

//        // POST: api/tasks
//        [HttpPost]
//        public ActionResult<Task> Create(Task task)
//        {
//            _repository.Add(task);
//            _repository.Save();
//            return CreatedAtAction(nameof(GetById), new { id = task.TaskId }, task);
//        }

//        // PUT: api/tasks/5
//        [HttpPut("{id}")]
//        public IActionResult Update(int id, Task updatedTask)
//        {
//            if (id != updatedTask.TaskId)
//                return BadRequest();

//            var existing = _repository.GetById(id);
//            if (existing == null)
//                return NotFound();

//            _repository.Update(updatedTask);
//            _repository.Save();
//            return NoContent();
//        }

//        // PATCH: api/tasks/5
//        [HttpPatch("{id}")]
//        public IActionResult Patch(int id, [FromBody] Dictionary<string, object> changes)
//        {
//            var task = _repository.GetById(id);
//            if (task == null)
//                return NotFound();

//            foreach (var change in changes)
//            {
//                var prop = task.GetType().GetProperty(change.Key);
//                if (prop != null && prop.CanWrite)
//                {
//                    prop.SetValue(task, Convert.ChangeType(change.Value, prop.PropertyType));
//                }
//            }

//            _repository.Update(task);
//            _repository.Save();
//            return NoContent();
//        }

//        // DELETE: api/tasks/5
//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var task = _repository.GetById(id);
//            if (task == null)
//                return NotFound();

//            _repository.Delete(id);
//            _repository.Save();
//            return NoContent();
//        }
//    }
//}
