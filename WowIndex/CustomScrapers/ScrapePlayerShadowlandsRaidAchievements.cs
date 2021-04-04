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
        public static List<Models.RaidAchievement> ScrapePlayerShadowlandsRaidAchievements(string region, string realm, string name)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load($"https://worldofwarcraft.com/en-gb/character/{region}/{realm}/{name}/achievements/dungeons-raids/shadowlands-raid");

            var scriptsInSource = doc.DocumentNode.Descendants().Where(n => n.Name == "script").ToList();

            // get player data
            string playerData = scriptsInSource[9].InnerHtml;

            // initial clean up
            string cleanedJsonData = playerData.Remove(0, 35);
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
                //var steps = new List<Models.POCO.ShadowlandsRaidPOCO.Step>();

                // get progress steps for this achievement
                /*
                foreach (WowIndex.Models.POCO.ShadowlandsRaidPOCO.Step step in item.progressSteps)
                {
                    steps.Add(new Models.POCO.ShadowlandsRaidPOCO.Step
                    {
                        completed = step.completed,
                        description = step.description
                    });
                }*/

                //var stepsTotal = steps.Count();
                //var stepsCompleted = steps.Where(x => x.completed == true).Count();

                // build result
                if(item.name.Split(':')[0].Equals("Mythic"))
                {
                    if(item.time.ToString().Equals("1/1/0001 12:00:00 AM"))
                    result.Add(new Models.RaidAchievement
                    {
                        Name = item.name,
                        Description = item.description,
                        isCompleted = false,
                        //StepsTotal = stepsTotal,
                        //StepsCompleted = stepsCompleted,
                        Time = item.time
                    });
                    else
                    {
                        result.Add(new Models.RaidAchievement
                        {
                            Name = item.name,
                            Description = item.description,
                            isCompleted = true,
                            //StepsTotal = stepsTotal,
                            //StepsCompleted = stepsCompleted,
                            Time = item.time
                        });
                    }
                }
                
            }

            return result;
        }
    }
}
