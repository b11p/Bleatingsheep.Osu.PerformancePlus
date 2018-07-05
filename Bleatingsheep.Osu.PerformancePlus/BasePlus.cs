using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bleatingsheep.Osu.PerformancePlus
{
    public abstract class BasePlus
    {
        private protected BasePlus()
        {
        }

        protected async Task<string> GetHtmlAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                string result;
                try
                {
                    result = await httpClient.GetStringAsync(url);
                }
                catch (Exception e)
                {
                    throw new ExceptionPlus("Network error.", e);
                }
                return result;
            }
        }
    }
}
