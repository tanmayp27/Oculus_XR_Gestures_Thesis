using System;

namespace Chain
{
    public class ChainEvents
    {
        public static Action<float, int> OnCogSpeedSet;

        public static Action OnMovieClipBegin;

        public static Action<int> OnCreateTeethPool;
    }
}
