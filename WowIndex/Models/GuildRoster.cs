using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Models
{
    public class GuildRoster
    {
        public int Id { get; set; }
        public int GuildId { get; set; }
        public string CharacterName { get; set; }
        public string RealmSlug { get; set; }
        public int MemberRank { get; set; }
        public string Region { get; set; }
        public string playable_class { get; set; }
        public string class_color { get; set; }
    }
}
