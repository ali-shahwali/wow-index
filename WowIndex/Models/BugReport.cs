using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Models
{
    public class BugReport
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public bool IsResolved { get; set; } = false;
    }
}
