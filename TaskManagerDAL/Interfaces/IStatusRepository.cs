using System.Collections.Generic;
using TaskManagerCommon.Entities;

namespace TaskManagerDAL.Interfaces
{
    public interface IStatusRepository
    {
        IEnumerable<Status> GetAllStatuses();

        Status GetStatusById(int statusId);

        void AddStatus(Status status);

        void UpdateStatus(Status status);

        void DeleteStatus(int statusId);
    }
}
