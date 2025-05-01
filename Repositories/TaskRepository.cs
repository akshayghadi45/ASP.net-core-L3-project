using CoreSkillsApp.Interfaces;
using CoreSkillsApp.Models;
using Microsoft.EntityFrameworkCore;
using Task = CoreSkillsApp.Models.Task;

namespace CoreSkillsApp.Repositories
{
    public class TaskRepository : IRepository<Task>
    {
        private readonly MyDbContext _context;

        public TaskRepository(MyDbContext context)
        {
            _context = context;
        }

        // Get all tasks
        public IEnumerable<Task> GetAll()
        {
            return _context.Tasks.AsNoTracking().ToList();
        }

        // Get task by ID
        public Task GetById(int id)
        {
            return _context.Tasks.AsNoTracking().FirstOrDefault(t => t.TaskId == id);
        }

        // Add a new task
        public void Add(Task task)
        {
            _context.Tasks.Add(task);
        }

        // Update a task (PUT/PATCH both use this)
        public void Update(Task task)
        {
            _context.Tasks.Update(task);
        }

        // Delete a task by ID
        public void Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
            }
        }

        // Save changes to DB
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}