using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Bleatingsheep.Osu.PerformancePlus
{
    public class UserPlus : IUserPlus
    {
        internal UserPlus(string id, string name, IReadOnlyList<string> pps)
        {
            Id = int.Parse(
                s: id,
                provider: CultureInfo.InvariantCulture
            );
            Name = name;
            var pp = pps.Select(s => int.Parse(
                s: s,
                style: NumberStyles.Integer | NumberStyles.AllowThousands,
                provider: CultureInfo.InvariantCulture
            )).ToList();
            Performance = pp[0];
            AimTotal = pp[1];
            AimJump = pp[2];
            AimFlow = pp[3];
            Precision = pp[4];
            Speed = pp[5];
            Stamina = pp[6];
            Accuracy = pp[7];
        }

        public int Id { get; }

        public string Name { get; }

        public int Performance { get; }

        public int AimTotal { get; }

        public int AimJump { get; }

        public int AimFlow { get; }

        public int Precision { get; }

        public int Speed { get; }

        public int Stamina { get; }

        public int Accuracy { get; }
    }
}
