using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TaskManagerCommon.Entities;
using TaskManagerDAL.Interfaces;

namespace TaskManagerDAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerContext _context;

        public TaskRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _context.Task.Include(t => t.Status).ToList();
        }

        public Task GetTaskById(int taskId)
        {
            return _context.Task.Include(t => t.Status).FirstOrDefault(t => t.ID == taskId);
        }

        public void AddTask(Task task)
        {
            _context.Task.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Task.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            var task = _context.Task.Find(taskId);
            if (task != null)
            {
                _context.Task.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
