using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Helpers
{
    public class RankColorHelper
    {
        public static Color GetColorByRank(int rank)
        {
            Color color = new Color();
            if (rank <= 3)
                color = Color.Primary;
            else if (rank <= 10)
                color = Color.Secondary;
            else if (rank <= 100)
                color = Color.Info;
            else if (rank <= 1000)
                color = Color.Success;
            else
                color = Color.Inherit;

            return color;
        }
    }
}
