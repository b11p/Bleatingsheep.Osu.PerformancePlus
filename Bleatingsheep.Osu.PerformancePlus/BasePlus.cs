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

        protected async Task<string> GetHtmlAsync(string url, bool ignore500 = false)
        {
            using (var httpClient = new HttpClient())
            {
                string result = string.Empty;
                try
                {
                    result = await httpClient.GetStringAsync(url);
                }
                catch (HttpRequestException re) when (re.Message.Contains("500"))
                {
                    if (!ignore500)
                        throw new InternalServerErrorExceptionPlus("500 Internal Server Error.", re);
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
