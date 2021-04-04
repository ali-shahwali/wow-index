using System;

namespace WowIndex.Models.POCO.ShadowlandsRaidPOCO
{

    public class ShadowlandsRaidPOCO
    {
        public Achievement[] achievements { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Achievement
    {
        public bool accountWide { get; set; }
        public string description { get; set; }
        public Icon icon { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int point { get; set; }
        public object[] progressSteps { get; set; }
        public Reward reward { get; set; }
        public Step[] steps { get; set; }
        public DateTime time { get; set; }
        public string url { get; set; }
    }

    public class Icon
    {
        public string url { get; set; }
    }

    public class Reward
    {
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Step
    {
        public bool completed { get; set; }
        public string description { get; set; }
        public Icon1 icon { get; set; }
        public bool isGold { get; set; }
        public string url { get; set; }
    }

    public class Icon1
    {
        public string url { get; set; }
    }
}