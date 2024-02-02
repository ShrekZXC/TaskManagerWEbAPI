using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerBLL.Interfaces;
using TaskManagerCommon.Models;
using TaskManagerCommon.ViewModels;

namespace TaskManagerPresentation.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IStatusService _statusService;
        private readonly ILogger<TasksController> _logger;
        private readonly IMapper _mapper;

        public TasksController(ILogger<TasksController> logger,
            IMapper mapper,
            ITaskService taskService,
            IStatusService statusService)
        {
            _taskService = taskService;
            _logger = logger;
            _mapper = mapper;
            _statusService = statusService;
        }

        [HttpGet]
        public JsonResult GetTasks()
        {
            var tasks = _taskService.GetAllTasks().ToList();

            var viewModel = _mapper.Map<List<TaskViewModel>>(tasks);

            return Json(viewModel);
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetStatuses()
        {
            var statuses = _statusService.GetStatuses();

            return Json(statuses);
        }

        [HttpPost]
        public JsonResult Edit([FromBody] int id)
        {
            var task = _mapper.Map<CreateUpdateViewModel>(_taskService.GetTaskById(id));

            return Json(task);
        }

        [HttpPost]
        public JsonResult Update([FromBody] CreateUpdateViewModel viewModel)
        {
            if(viewModel == null)
            {
                return Json("Ошибка при обновлении задачи");
            }
            if(!ModelState.IsValid)
            {
                return Json("Ошибка при обновлении задачи");
            }

            var task = _mapper.Map<TaskModel>(viewModel);

            _taskService.UpdateTask(task);

            return Json("Задача обновлена");
        }

        [HttpPost]
        public JsonResult Create([FromBody] CreateUpdateViewModel viewModel)
        {
            if (viewModel == null)
            {
                return Json("Ошибка при создании задачи");
            }

            if (!ModelState.IsValid)
            {
                return Json("Ошибка при создании задачи");
            }

            var taskModel = _mapper.Map<TaskModel>(viewModel);
            _taskService.CreateTask(taskModel);

            return Json("Задача добавлена");
        }

        [HttpPost]
        public JsonResult Delete([FromBody] int id)
        {
            if (id == 0)
            {
                return Json("Ошибка при удалении задачи");
            }

            if (!ModelState.IsValid)
            {
                return Json("Ошибка при удалении задачи");
            }

            _taskService.DeleteTaks(id);

            return Json("Задача Удалена");
        }
    }
}
