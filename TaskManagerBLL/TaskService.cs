using System.Collections.Generic;
using TaskManagerDAL.Interfaces;
using TaskManagerBLL.Interfaces;
using AutoMapper;
using System.Linq;
using TaskManagerCommon.Models;
using Task = TaskManagerCommon.Entities.Task;

namespace TaskManagerBLL
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public TaskService()
        {
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            var tasks = _taskRepository.GetAllTasks();

            var tasksModel = _mapper.Map<List<TaskModel>>(tasks.ToList());

            return tasksModel;
        }

        public void CreateTask(TaskModel taskModel)
        {
            var task = _mapper.Map<Task>(taskModel);

            _taskRepository.AddTask(task);
        }

        public TaskModel GetTaskById(int taskId)
        {
            var task = _taskRepository.GetTaskById(taskId);

            var taskModel = _mapper.Map<TaskModel>(task);

            return taskModel;
        }

        public void UpdateTask(TaskModel taskModel)
        {
            var task = _mapper.Map<Task>(taskModel);

            _taskRepository.UpdateTask(task);
        }

        public void DeleteTaks(int id)
        {
            _taskRepository.DeleteTask(id);
        }
    }
}
