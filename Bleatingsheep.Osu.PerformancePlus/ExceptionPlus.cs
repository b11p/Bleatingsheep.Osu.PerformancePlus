using System;

namespace Bleatingsheep.Osu.PerformancePlus
{

    [Serializable]
    public class ExceptionPlus : Exception
    {
        public ExceptionPlus() { }
        public ExceptionPlus(string message) : base(message) { }
        public ExceptionPlus(string message, Exception inner) : base(message, inner) { }
        protected ExceptionPlus(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
