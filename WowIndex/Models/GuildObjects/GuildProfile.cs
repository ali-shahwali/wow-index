using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Models.GuildObjects
{
    public class GuildProfile
    {
        public int Id { get; set; }

        public Guild Guild { get; set; }

        public string Biography { get; set; }

        public bool IsRecruiting { get; set; }

    }
}
