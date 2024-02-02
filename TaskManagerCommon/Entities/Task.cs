using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerCommon.Entities
{
    public class Task
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }
    }
}
