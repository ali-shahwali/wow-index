namespace WowIndex.Models.characterMedia
{

    public class WowCharacterMediaPOCO
    {
        public _Links _links { get; set; }
        public Character character { get; set; }
        public string avatar_url { get; set; }
        public string bust_url { get; set; }
        public string render_url { get; set; }
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
}