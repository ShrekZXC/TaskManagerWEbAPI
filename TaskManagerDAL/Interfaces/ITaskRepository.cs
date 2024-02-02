using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerCommon.Entities;

namespace TaskManagerDAL.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAllTasks();
        Task GetTaskById(int taskId);
        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(int taskId);
    }
}
