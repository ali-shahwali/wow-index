namespace WowIndex.Models.POCO.CharacterAchievementPOCO
{
    public class CharacterAchievement
    {
        public _Links _links { get; set; }
        public int total_quantity { get; set; }
        public int total_points { get; set; }
        public Achievement[] achievements { get; set; }
        public Category_Progress[] category_progress { get; set; }
        public Recent_Events[] recent_events { get; set; }
        public Character character { get; set; }
        public Statistics statistics { get; set; }
    }

    public class _Links
    {
        public Self self { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Character
    {
        public Key key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public Realm realm { get; set; }
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

    public class Statistics
    {
        public string href { get; set; }
    }

    public class Achievement
    {
        public int id { get; set; }
        public Achievement1 achievement { get; set; }
        public Criteria criteria { get; set; }
        public System.Numerics.BigInteger completed_timestamp { get; set; }
    }

    public class Achievement1
    {
        public Key2 key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Key2
    {
        public string href { get; set; }
    }

    public class Criteria
    {
        public int id { get; set; }
        public bool is_completed { get; set; }
        public Child_Criteria[] child_criteria { get; set; }
        public int amount { get; set; }
    }

    public class Child_Criteria
    {
        public int id { get; set; }
        public System.Numerics.BigInteger amount { get; set; }
        public bool is_completed { get; set; }
        public Child_Criteria1[] child_criteria { get; set; }
    }

    public class Child_Criteria1
    {
        public int id { get; set; }
        public int amount { get; set; }
        public bool is_completed { get; set; }
        public Child_Criteria2[] child_criteria { get; set; }
    }

    public class Child_Criteria2
    {
        public int id { get; set; }
        public bool is_completed { get; set; }
        public int amount { get; set; }
    }

    public class Category_Progress
    {
        public Category category { get; set; }
        public int quantity { get; set; }
        public int points { get; set; }
    }

    public class Category
    {
        public Key3 key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Key3
    {
        public string href { get; set; }
    }

    public class Recent_Events
    {
        public Achievement2 achievement { get; set; }
        public System.Numerics.BigInteger timestamp { get; set; }
    }

    public class Achievement2
    {
        public Key4 key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Key4
    {
        public string href { get; set; }
    }
}


