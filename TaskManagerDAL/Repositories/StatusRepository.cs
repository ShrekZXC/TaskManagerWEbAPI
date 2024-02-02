using System.Collections.Generic;
using System.Linq;
using TaskManagerCommon.Entities;
using TaskManagerDAL.Interfaces;

namespace TaskManagerDAL.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly TaskManagerContext _context;

        public StatusRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<Status> GetAllStatuses()
        {
            return _context.Status.ToList();
        }

        public Status GetStatusById(int statusId)
        {
            return _context.Status.Find(statusId);
        }

        public void AddStatus(Status status)
        {
            _context.Status.Add(status);
            _context.SaveChanges();
        }

        public void UpdateStatus(Status status)
        {
            _context.Status.Update(status);
            _context.SaveChanges();
        }

        public void DeleteStatus(int statusId)
        {
            var status = _context.Status.Find(statusId);
            if (status != null)
            {
                _context.Status.Remove(status);
                _context.SaveChanges();
            }
        }
    }
}
