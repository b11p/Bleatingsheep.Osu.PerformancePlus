using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bleatingsheep.Osu.PerformancePlus
{
    public class PerformancePlusSpider : BasePlus, IPerformancePlus
    {
        private static readonly IReadOnlyList<Regex> UserRegices;
        private static readonly IReadOnlyList<Regex> BeatmapRegices;

        static PerformancePlusSpider()
        {
            IReadOnlyList<string> userPatterns = new[]
            {
                @"<th>Performance:</th><th>([\d,]+)pp</th>",
                @"<td>Aim \(Total\):</td><td>([\d,]+)pp</td>",
                @"<td>Aim \(Jump\):</td><td>([\d,]+)pp</td>",
                @"<td>Aim \(Flow\):</td><td>([\d,]+)pp</td>",
                @"<td>Precision:</td><td>([\d,]+)pp</td>",
                @"<td>Speed:</td><td>([\d,]+)pp</td>",
                @"<td>Stamina:</td><td>([\d,]+)pp</td>",
                @"<td>Accuracy:</td><td>([\d,]+)pp</td>",
            };

            IReadOnlyList<string> beatmapPatterns = new[]
            {
                @"<h3><strong>([\d\.]+) stars</strong></h3>",
                @"<p>([\d\.]+) <small>stars</small></p>",
                @"<p>([\d\.]+) <small>stars</small></p>",
                @"<p>([\d\.]+) <small>stars</small></p>",
                @"<p>([\d\.]+) <small>stars</small></p>",
                @"<p>([\d\.]+) <small>stars</small></p>",
                @"<p>([\d\.]+) <small>stars</small></p>",
                @"<p>([\d\.]+) <small>stars</small></p>",
            };

            UserRegices = userPatterns.Select(p => new Regex(p, RegexOptions.Compiled)).ToList();

            BeatmapRegices = beatmapPatterns.Select(b => new Regex(b, RegexOptions.Compiled)).ToList();
        }

        private UserPlus ParseHtmlToUserPlus(string html)
        {
            const string userPattern = "<a href=\"https://osu.ppy.sh/u/(\\d+)\">([A-Za-z0-9\\-_ ]+?)</a>";
            var userMatch = Regex.Match(html, userPattern, RegexOptions.Compiled);
            if (!userMatch.Success) return null;

            // Start at the end of last match
            int index = userMatch.Index + userMatch.Length;
            var regices = UserRegices;

            string[] result = Match(html, ref index, regices);
            return result == null ? null : new UserPlus(userMatch.Groups[1].Value, userMatch.Groups[2].Value, result);
        }

        private static string[] Match(string html, ref int index, IEnumerable<Regex> regices)
        {
            IReadOnlyList<Regex> fixedRegices = regices.ToList();
            var result = new string[fixedRegices.Count];
            for (int i = 0; i < result.Length; i++)
            {
                var recentMatch = fixedRegices[i].Match(input: html, startat: index);
                if (!recentMatch.Success) return null;
                index = recentMatch.Index + recentMatch.Length;
                result[i] = recentMatch.Groups[1].Value;
            }

            return result;
        }

        private BeatmapPlus ParseHtmlToBeatmapPlus(string html, int beatmapId)
        {
            int index = 0;
            string[] result = Match(html, ref index, BeatmapRegices);
            return result == null ? null : new BeatmapPlus(beatmapId, result);
        }

        /// <exception cref="ExceptionPlus"/>
        public async Task<IUserPlus> GetUserPlusAsync(int id)
        {
            string html = await GetHtmlAsync(string.Format(CultureInfo.InvariantCulture, "https://syrin.me/pp+/u/{0}/", id));
            return ParseHtmlToUserPlus(html);
        }

        /// <exception cref="ExceptionPlus"/>
        public async Task<IBeatmapPlus> GetBeatmapPlusAsync(int id)
        {
            string html = await GetHtmlAsync(string.Format(CultureInfo.InvariantCulture, "https://syrin.me/pp+/b/{0}/", id));
            return ParseHtmlToBeatmapPlus(html, id);
        }
    }
}
