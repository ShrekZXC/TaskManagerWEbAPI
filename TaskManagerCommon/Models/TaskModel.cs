namespace TaskManagerCommon.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int StatusId { get; set; }
        public StatusModel Status { get; set; }
    }
}
