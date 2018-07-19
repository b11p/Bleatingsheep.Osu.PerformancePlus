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

        protected UserPlus()
        {
        }

        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public int Performance { get; protected set; }

        public int AimTotal { get; protected set; }

        public int AimJump { get; protected set; }

        public int AimFlow { get; protected set; }

        public int Precision { get; protected set; }

        public int Speed { get; protected set; }

        public int Stamina { get; protected set; }

        public int Accuracy { get; protected set; }
    }
}
