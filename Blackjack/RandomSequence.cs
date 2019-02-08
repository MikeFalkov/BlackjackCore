using System;

namespace BlackjackCore
{
    public class RandomSequence : IRandomSequence
    {

        private Random _rnd = new Random();
        public int Next()
        {
            return _rnd.Next();
        }
    }
}