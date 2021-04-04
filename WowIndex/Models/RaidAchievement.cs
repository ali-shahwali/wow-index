using System;

namespace WowIndex.Models
{
    public class RaidAchievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StepsTotal { get; set; }
        public int StepsCompleted { get; set; }
        public DateTime Time { get; set; }
    }
}
