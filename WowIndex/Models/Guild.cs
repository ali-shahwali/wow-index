using System;

namespace WowIndex.Models
{
    public class Guild
    {
        public int Id { get; set; }

        public int GuildId { get; set; }

        public DateTime RecordCreationDate { get; set; }

        public string Name { get; set; }

        public string NameSlug { get; set; }

        public string Region { get; set; }

        public string Realm { get; set; }

        public string RealmSlug { get; set; }

        public int RealmId { get; set; }

        public string FactionType { get; set; }

        public string FactionName { get; set; }
    }
}
