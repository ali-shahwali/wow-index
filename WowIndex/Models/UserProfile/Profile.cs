using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Models.UserProfile
{
    public class Profile
    {
        public int Id { get; set; }

        public string AspEmail { get; set; }

        public string BattleTag { get; set; }

        public string ProfileUri { get; set; }
    }
}
