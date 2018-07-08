using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Bleatingsheep.Osu.PerformancePlus
{
    public class BeatmapPlus : IBeatmapPlus
    {
        internal BeatmapPlus(int id, IReadOnlyList<string> stars)
        {
            Id = id;
            var star = stars.Select(s => float.Parse(
                s: s,
                style: NumberStyles.Float,
                provider: CultureInfo.InvariantCulture
            )).ToList();
            Stars = star[0];
            AimTotal = star[1];
            AimJump = star[2];
            AimFlow = star[3];
            Precision = star[4];
            Speed = star[5];
            Stamina = star[6];
            Accuracy = star[7];
        }

        public int Id { get; }

        public float Stars { get; }

        public float AimTotal { get; }

        public float AimJump { get; }

        public float AimFlow { get; }

        public float Precision { get; }

        public float Speed { get; }

        public float Stamina { get; }

        public float Accuracy { get; }
    }
}
