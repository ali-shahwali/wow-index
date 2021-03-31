namespace WowIndex.Models.UserAccount
{
    public class WoWUserProfilePOCO
    {
        public _Links _links { get; set; }
        public int id { get; set; }
        public Wow_Accounts[] wow_accounts { get; set; }
        public Collections collections { get; set; }
    }

    public class _Links
    {
        public Self self { get; set; }
        public User user { get; set; }
        public Profile profile { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class User
    {
        public string href { get; set; }
    }

    public class Profile
    {
        public string href { get; set; }
    }

    public class Collections
    {
        public string href { get; set; }
    }

    public class Wow_Accounts
    {
        public int id { get; set; }
        public Character[] characters { get; set; }
    }

    public class Character
    {
        public Character1 character { get; set; }
        public Protected_Character protected_character { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public Realm realm { get; set; }
        public Playable_Class playable_class { get; set; }
        public Playable_Race playable_race { get; set; }
        public Gender gender { get; set; }
        public Faction faction { get; set; }
        public int level { get; set; }
    }

    public class Character1
    {
        public string href { get; set; }
    }

    public class Protected_Character
    {
        public string href { get; set; }
    }

    public class Realm
    {
        public Key key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
    }

    public class Key
    {
        public string href { get; set; }
    }

    public class Playable_Class
    {
        public Key1 key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Key1
    {
        public string href { get; set; }
    }

    public class Playable_Race
    {
        public Key2 key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Key2
    {
        public string href { get; set; }
    }

    public class Gender
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Faction
    {
        public string type { get; set; }
        public string name { get; set; }
    }

}
