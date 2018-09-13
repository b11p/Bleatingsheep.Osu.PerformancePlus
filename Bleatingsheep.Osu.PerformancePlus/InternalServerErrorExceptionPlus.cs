using System;

namespace Bleatingsheep.Osu.PerformancePlus
{
    [Serializable]
    public class InternalServerErrorExceptionPlus : ExceptionPlus
    {
        public InternalServerErrorExceptionPlus() { }
        public InternalServerErrorExceptionPlus(string message) : base(message) { }
        public InternalServerErrorExceptionPlus(string message, Exception inner) : base(message, inner) { }
        protected InternalServerErrorExceptionPlus(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
