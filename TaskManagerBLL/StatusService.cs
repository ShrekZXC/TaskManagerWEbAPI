using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerBLL.Interfaces;
using TaskManagerCommon.Models;
using TaskManagerDAL.Interfaces;

namespace TaskManagerBLL
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public StatusService(IStatusRepository statusRepository,
            IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }
        public List<StatusModel> GetStatuses()
        {
            var statusList = _statusRepository.GetAllStatuses();

            var statusModelList = _mapper.Map<List<StatusModel>>(statusList.ToList());

            return statusModelList;
        }
    }
}
