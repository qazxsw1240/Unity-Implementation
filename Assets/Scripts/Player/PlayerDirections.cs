using System;

namespace Implementation.Player
{
    [Flags]
    public enum PlayerDirections
    {
        None = 0,
        Frontward = 1,
        Backward = 2,
        Left = 4,
        Right = 8
    }
}
