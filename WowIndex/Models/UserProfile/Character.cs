using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Models.UserProfile
{
    public class Character
    {
        public int Id { get; set; }

        // Email
        public string Email { get; set; }

        public string CharacterName { get; set; }

        public string Realm { get; set; }

        public string RealmSlug { get; set; }

        public int Level { get; set; }

        public string Faction { get; set; }
        
        public string Race { get; set; }

        public string Region { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Gender { get; set; }

        public string avatar_url { get; set; }

        public string bust_url { get; set; }

        public string render_url { get; set; }
    }
}
