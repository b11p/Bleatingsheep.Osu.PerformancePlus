using System.Threading.Tasks;
using Xunit;

namespace Bleatingsheep.Osu.PerformancePlus.Tests
{
    public class BeatmapPlusTests
    {
        [Fact]
        public async Task InternalServerErrorAsync()
        {
            const int Id = 760464;
            var ppp = new PerformancePlusSpider();
            ppp.IgnoreInternalServerError = false;
            await Assert.ThrowsAsync<InternalServerErrorExceptionPlus>(async () =>
            {
                await ppp.GetBeatmapPlusAsync(Id);
            });

            ppp.IgnoreInternalServerError = true;
            Assert.Null(await ppp.GetBeatmapPlusAsync(Id));
        }
    }
}
