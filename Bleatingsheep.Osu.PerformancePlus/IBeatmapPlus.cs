namespace Bleatingsheep.Osu.PerformancePlus
{
    public interface IBeatmapPlus
    {
        int Id { get; }
        float Stars { get; }
        float AimTotal { get; }
        float AimJump { get; }
        float AimFlow { get; }
        float Precision { get; }
        float Speed { get; }
        float Stamina { get; }
        float Accuracy { get; }
    }
}
