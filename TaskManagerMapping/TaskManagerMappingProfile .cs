using AutoMapper;
using System;
using TaskManagerCommon.Entities;
using TaskManagerCommon.Models;
using TaskManagerCommon.ViewModels;

namespace TaskManagerMapping
{
    public class TaskManagerMappingProfile : Profile
    {
        public TaskManagerMappingProfile()
        {
            // Status
            CreateMap<StatusViewModel, StatusModel>().ReverseMap();
            CreateMap<StatusModel, Status>().ReverseMap();

            //Task
            CreateMap<TaskViewModel, TaskModel>().ReverseMap();
            CreateMap<TaskModel, Task>().ReverseMap();

            CreateMap<CreateUpdateViewModel, TaskModel>().ReverseMap();
        }

    }
}
