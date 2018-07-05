using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bleatingsheep.Osu.PerformancePlus
{
    public class PerformancePlusSpider : BasePlus, IPerformancePlus
    {
        private static readonly IReadOnlyList<Regex> UserRegices;

        static PerformancePlusSpider()
        {
            IReadOnlyList<string> userPatterns = new[]
            {
                @"<th>Performance:</th><th>([\d,]+)pp</th>",
                @"<td>Aim (Total):</td><td>([\d,]+)pp</td>",
                @"<td>Aim (Jump):</td><td>([\d,]+)pp</td>",
                @"<td>Aim (Flow):</td><td>([\d,]+)pp</td>",
                @"<td>Precision:</td><td>([\d,]+)pp</td>",
                @"<td>Speed:</td><td>([\d,]+)pp</td>",
                @"<td>Stamina:</td><td>([\d,]+)pp</td>",
                @"<td>Accuracy:</td><td>([\d,]+)pp</td>",
            };

            var regices = new Regex[userPatterns.Count];
            for (int i = 0; i < userPatterns.Count; i++)
            {
                regices[i] = new Regex(userPatterns[i], RegexOptions.Compiled);
            }
            UserRegices = regices;
        }

        private UserPlus ParseHtmlToUserPlus(string html)
        {
            string userPattern = "<a href=\"https://osu.ppy.sh/u/(\\d+)\">([A-Za-z0-9\\-_]+?)</a>";
            var userMatch = Regex.Match(html, userPattern, RegexOptions.Compiled);
            if (!userMatch.Success) return null;

            int index = 0;
            var result = new string[UserRegices.Count];
            for (int i = 0; i < result.Length; i++)
            {
                var recentMatch = UserRegices[i].Match(input: html, startat: index);
                if (!recentMatch.Success) return null;
                index = recentMatch.Index + recentMatch.Length;
                result[i] = recentMatch.Groups[1].Value;
            }
            return new UserPlus(userMatch.Groups[1].Value, userMatch.Groups[2].Value, result);
        }

        /// <exception cref="ExceptionPlus"/>
        public async Task<IUserPlus> GetUserPlusAsync(int id)
        {
            string html = await GetHtmlAsync($"https://syrin.me/pp+/u/{id.ToString(CultureInfo.InvariantCulture)}/");
            return ParseHtmlToUserPlus(html);
        }
    }
}
