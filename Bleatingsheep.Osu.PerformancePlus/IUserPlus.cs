namespace Bleatingsheep.Osu.PerformancePlus
{
    public interface IUserPlus
    {
        int Id { get; }
        string Name { get; }

        int Performance { get; }
        int AimTotal { get; }
        int AimJump { get; }
        int AimFlow { get; }
        int Precision { get; }
        int Speed { get; }
        int Stamina { get; }
        int Accuracy { get; }
    }
}
