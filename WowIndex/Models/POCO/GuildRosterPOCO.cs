namespace WowIndex.Models.POCO
{
    public class GuildRosterPOCO
    {
        public _Links _links { get; set; }
        public Guild guild { get; set; }
        public Member[] members { get; set; }
    }

    public class _Links
    {
        public Self self { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Guild
    {
        public Key key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public Realm realm { get; set; }
        public Faction faction { get; set; }
    }

    public class Key
    {
        public string href { get; set; }
    }

    public class Realm
    {
        public Key1 key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
    }

    public class Key1
    {
        public string href { get; set; }
    }

    public class Faction
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Member
    {
        public Character character { get; set; }
        public int rank { get; set; }
    }

    public class Character
    {
        public Key2 key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public Realm1 realm { get; set; }
        public int level { get; set; }
        public Playable_Class playable_class { get; set; }
        public Playable_Race playable_race { get; set; }
    }

    public class Key2
    {
        public string href { get; set; }
    }

    public class Realm1
    {
        public Key3 key { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
    }

    public class Key3
    {
        public string href { get; set; }
    }

    public class Playable_Class
    {
        public Key4 key { get; set; }
        public int id { get; set; }
    }

    public class Key4
    {
        public string href { get; set; }
    }

    public class Playable_Race
    {
        public Key5 key { get; set; }
        public int id { get; set; }
    }

    public class Key5
    {
        public string href { get; set; }
    }
}

