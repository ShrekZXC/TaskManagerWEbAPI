using System.Collections.Generic;
using TaskManagerCommon.Models;

namespace TaskManagerBLL.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskModel> GetAllTasks();

        void CreateTask(TaskModel taskModel);

        TaskModel GetTaskById(int taskId);

        void UpdateTask(TaskModel taskModel);
        void DeleteTaks(int id);
    }
}
