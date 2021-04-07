using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Helpers
{
    public class WowClassHelper
    {

        public static string GetClassColour(int id)
        {
            string[] colors = {
               "color: #c69b6d", // warrior
               "color: #f48cba", // pal
               "color: #aad372", // hunter
               "color: #fff468", // rogue
               "color: #f0ebe0", // priest
               "color: #c41e3b", // DK
               "color: #2359ff", // sham
               "color: #68ccef", // mage
               "color: #9382c9", // warlock
               "color: #00ffba", // monk
               "color:#ff7c0a", // druid
               "color: #a330c9" // DH
            };

            return colors[id - 1];
        }

        public static string GetClassById(int id)
        {
            //priest 5
            //rogue 4
            //shaman 7
            //warlock 9
            //warrior 1
            //paladin 2
            //monk 10
            //mage 8
            //hunter 3
            //druid 11
            //demon hunter 12
            //death knight 6
            string[] classes =
                {
                    "Warrior", "Paladin", "Hunter", "Rogue", "Priest", "Death Knight",
                    "Shaman", "Mage", "Warlock", "Monk", "Druid", "Demon Hunter"
                };

            return classes[id - 1];
            
        }
    }
}
