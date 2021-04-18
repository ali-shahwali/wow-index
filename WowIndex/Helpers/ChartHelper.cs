using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowIndex.Data;
using ChartJs.Blazor.LineChart;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Util;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;

namespace WowIndex.Helpers
{
    public class ChartHelper
    {
        public static PieConfig GetRegionPieChart(ApplicationDbContext _context)
        {
            string[] labels = { "US", "EU", "KR", "TW" };
            int[] data = new int[4];

            PieConfig _config;
            for (int i = 0; i < 4; i++)
                data[i] = _context.RankedCastleNathriaLeaderboard.Where(x => x.Guild.Region == labels[i].ToLower()).Count();

            _config = new PieConfig
            {
                Options = new PieOptions
                {
                    Responsive = true,
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Region Representation",
                        FontColor = ColorUtil.ColorHexString(255, 255, 255),
                        FontSize = 16,
                    },
                    Legend = new Legend
                    {
                        Labels = new LegendLabels
                        {
                            FontColor = ColorUtil.ColorHexString(255, 255, 255)
                        }
                    },
                }
            };

            foreach (string label in labels)
                _config.Data.Labels.Add(label);

            PieDataset<int> dataset = new PieDataset<int>(data)
            {
                BackgroundColor = new[]
                {
                ColorUtil.ColorHexString(29, 140, 248),
                ColorUtil.ColorHexString(65, 175, 126),
                ColorUtil.ColorHexString(253, 93, 147),
                ColorUtil.ColorHexString(91, 6, 189)
                },
                BorderColor = ColorUtil.ColorHexString(50, 51, 61),
                HoverBorderWidth = 5,
            };

            _config.Data.Datasets.Add(dataset);

            return _config;
        }

        public static LineConfig GetClearsLineChart(ApplicationDbContext _context)
        {
            LineConfig _config;
            DateTime releaseDate = new DateTime(2020, 12, 8);
            int daysSinceRelease = (int)Math.Floor((DateTime.Now - releaseDate).TotalDays);

            int[] data = new int[daysSinceRelease];
            int clears = 0;
            for (int i = 0; i < daysSinceRelease; i++)
            {
                clears += _context.RankedCastleNathriaLeaderboard.Where(x => x.Progression == 10 && x.LatestProgressionTime.Year == releaseDate.Year && x.LatestProgressionTime.Month == releaseDate.Month && x.LatestProgressionTime.Day == releaseDate.Day).Count();
                data[i] = clears;
                releaseDate = releaseDate.AddDays(1);
            }

            _config = new LineConfig
            {
                Options = new LineOptions
                {
                    Responsive = true,
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Clears over time",
                        FontColor = ColorUtil.ColorHexString(255, 255, 255),
                        FontSize = 16
                    },
                    Legend = new Legend
                    {
                        Display = false
                    },
                    
                }
            };

            releaseDate = new DateTime(2020, 12, 8);
            for (int i = 0; i < daysSinceRelease; i++)
            {
                _config.Data.Labels.Add(releaseDate.ToShortDateString());
                releaseDate = releaseDate.AddDays(1);
            }

            LineDataset<int> lineDataSet = new LineDataset<int>(data)
            {
                BorderColor = ColorUtil.ColorHexString(255, 128, 0),
                CubicInterpolationMode = CubicInterpolationMode.Monotone,
                PointRadius = 0
            };

            _config.Data.Datasets.Add(lineDataSet);

            return _config;
        }

        public static BarConfig GetRosterClassBarChart(List<Models.GuildObjects.GuildRoster> guildMembers,ApplicationDbContext _context)
        {
            BarConfig _config;

            string[] classLabels =
            {
                "Warrior", "Paladin", "Hunter", "Rogue", "Priest", "Death Knight",
                "Shaman", "Mage", "Warlock", "Monk", "Druid", "Demon Hunter"
            };

            int[] classData = new int[12];

            int i = 0;
            foreach (var className in classLabels)
                classData[i++] = guildMembers.Where(x => x.playable_class == className).Count();

            _config = new BarConfig
            {
                Options = new BarOptions
                {
                    Responsive = true,
                    Title = new OptionsTitle
                    {
                        Display = false,
                    },
                    Legend = new Legend
                    {
                        Display = false
                    },
                    Scales = new BarScales
                    {
                        YAxes = new List<CartesianAxis>
                    {
                        new LinearCartesianAxis
                        {
                            Ticks = new LinearCartesianTicks
                            {
                                BeginAtZero = true
                            }
                        }
                    }
                    }
                }
            };

            foreach (string label in classLabels)
                _config.Data.Labels.Add(label);

            BarDataset<int> dataset = new BarDataset<int>(classData)
            {
                BackgroundColor = new[]
                {
                ColorUtil.ColorHexString(198,155,109),
                ColorUtil.ColorHexString(244,140,186),
                ColorUtil.ColorHexString(170,211,114),
                ColorUtil.ColorHexString(255,244,104),
                ColorUtil.ColorHexString(240,235,224),
                ColorUtil.ColorHexString(196,30,59),
                ColorUtil.ColorHexString(35,89,255),
                ColorUtil.ColorHexString(104,204,239),
                ColorUtil.ColorHexString(147,130,201),
                ColorUtil.ColorHexString(0,255,186),
                ColorUtil.ColorHexString(255,124,10),
                ColorUtil.ColorHexString(163,48,201)
            },
                BorderColor = ColorUtil.ColorHexString(50, 51, 61),
                HoverBorderWidth = 5
            };

            _config.Data.Datasets.Add(dataset);

            return _config;
        }
    }
}
