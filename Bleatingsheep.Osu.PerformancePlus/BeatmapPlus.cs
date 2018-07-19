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

        protected BeatmapPlus()
        {
        }

        public int Id { get; protected set; }

        public float Stars { get; protected set; }

        public float AimTotal { get; protected set; }

        public float AimJump { get; protected set; }

        public float AimFlow { get; protected set; }

        public float Precision { get; protected set; }

        public float Speed { get; protected set; }

        public float Stamina { get; protected set; }

        public float Accuracy { get; protected set; }
    }
}
