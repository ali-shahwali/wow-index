using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WowIndex.CustomScrapers
{
    public static class CustomScrapers
    {
        /// <summary>
        /// Returns a list of players raid achievements from the Shadowlands Expansion
        /// </summary>
        /// <returns></returns>
        public static List<Models.RaidAchievement> ScrapePlayerShadowlandsRaidAchievements(string region, string realm, string name)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load($"https://worldofwarcraft.com/en-gb/character/{region}/{realm}/{name}/achievements/dungeons-raids/shadowlands-raid");

            string playerData = doc.DocumentNode.Descendants().Where(n => n.Name == "script").ToList()[9].InnerHtml;

            string cleanedJsonData = playerData.Remove(0, 35);
            cleanedJsonData = cleanedJsonData.Remove(cleanedJsonData.Length - 2, 2);
            JObject obj = JObject.Parse(cleanedJsonData);

            // drill 1
            JToken achievementCategory = obj.SelectToken("achievementCategory");

            // drill 2
            JToken subcategories = achievementCategory.SelectToken("subcategories");

            // drill 3 (shadowlands raid achivemnts)
            JToken ShadowlandsRaid = subcategories.SelectToken("shadowlands-raid");

            // throw it in a poco object
            Models.POCO.ShadowlandsRaidPOCO.ShadowlandsRaidPOCO jsonObject = JsonConvert.DeserializeObject<Models.POCO.ShadowlandsRaidPOCO.ShadowlandsRaidPOCO>(ShadowlandsRaid.ToString());

            // chuck it into a list we can use
            List<Models.RaidAchievement> result = new List<Models.RaidAchievement>();

            foreach (Models.POCO.ShadowlandsRaidPOCO.Achievement item in jsonObject.achievements)
            {
                result.Add(new Models.RaidAchievement
                {
                    Name = item.name,
                    Description = item.description,
                    isCompleted = !item.time.ToString().Equals("1/1/0001 12:00:00 AM"),
                    Time = item.time
                });
            }

            return result;
        }
    }
}
