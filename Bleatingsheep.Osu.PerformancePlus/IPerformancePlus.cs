using System.Threading.Tasks;

namespace Bleatingsheep.Osu.PerformancePlus
{
    interface IPerformancePlus
    {
        Task<IUserPlus> GetUserPlusAsync(int id);
    }
}
