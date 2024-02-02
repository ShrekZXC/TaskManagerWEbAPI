using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerCommon.Models;

namespace TaskManagerBLL.Interfaces
{
    public interface IStatusService
    {
        List<StatusModel> GetStatuses();
    }
}
