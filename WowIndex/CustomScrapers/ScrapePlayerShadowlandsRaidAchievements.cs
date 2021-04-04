using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.CustomScrapers
{
    public static class CustomScrapers
    {
        /// <summary>
        /// Returns a list of players raid achievements from the Shadowlands Expansion
        /// </summary>
        /// <returns></returns>
        public static List<Models.RaidAchievement> ScrapePlayerShadowlandsRaidAchievements(string _region, string _realm, string _name)
        {
            var region = _region;
            var realm = _realm;
            var name = _name;

            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load($"https://worldofwarcraft.com/en-gb/character/{region}/{realm}/{name}/achievements/dungeons-raids/shadowlands-raid");

            var scriptsInSource = doc.DocumentNode.Descendants().Where(n => n.Name == "script").ToList();

            // get player data
            var playerData = scriptsInSource[9].InnerHtml;

            // initial clean up
            var cleanedJsonData = playerData.Remove(0, 35);
            cleanedJsonData = cleanedJsonData.Remove(cleanedJsonData.Length - 2, 2);
            JObject obj = JObject.Parse(cleanedJsonData);

            // drill 1
            var achievementCategory = obj.SelectToken("achievementCategory");

            // drill 2
            var subcategories = achievementCategory.SelectToken("subcategories");

            // drill 3 (shadowlands raid achivemnts)
            var ShadowlandsRaid = subcategories.SelectToken("shadowlands-raid");

            // throw it in a poco object
            var jsonObject = JsonConvert.DeserializeObject<Models.POCO.ShadowlandsRaidPOCO.ShadowlandsRaidPOCO>(ShadowlandsRaid.ToString());

            // chuck it into a list we can use
            List<Models.RaidAchievement> result = new List<Models.RaidAchievement>();

            foreach (var item in jsonObject.achievements)
            {
                var steps = new List<Models.POCO.ShadowlandsRaidPOCO.Step>();

                // get progress steps for this achievement
                foreach (WowIndex.Models.POCO.ShadowlandsRaidPOCO.Step step in item.progressSteps)
                {
                    steps.Add(new Models.POCO.ShadowlandsRaidPOCO.Step
                    {
                        completed = step.completed,
                        description = step.description
                    });
                }

                var stepsTotal = steps.Count();
                var stepsCompleted = steps.Where(x => x.completed == true).Count();

                // build result
                result.Add(new Models.RaidAchievement
                {
                    Name = item.name,
                    Description = item.description,
                    StepsTotal = stepsTotal,
                    StepsCompleted = stepsCompleted,
                    Time = item.time
                });
            }

            return result;
        }
    }
}
