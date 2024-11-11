using System.Collections.Generic;
using Implementation.Player;
using UnityEngine;

namespace Implementation.Inputs
{
    public static class MoveInputUtils
    {
        public static (Vector3, PlayerDirections) FromInput(InputProfile inputProfile, IList<InputEvent> inputEvents)
        {
            int forward = 0;
            int side = 0;
            PlayerDirections playerDirections = PlayerDirections.None;
            foreach (InputEvent inputEvent in inputEvents)
            {
                if (inputEvent.KeyCode == inputProfile.ForwardKey)
                {
                    forward += 1;
                    playerDirections |= PlayerDirections.Frontward;
                }
                else if (inputEvent.KeyCode == inputProfile.BackwardKey)
                {
                    forward -= 1;
                    playerDirections |= PlayerDirections.Backward;
                }
                else if (inputEvent.KeyCode == inputProfile.LeftKey)
                {
                    side += 1;
                    playerDirections |= PlayerDirections.Left;
                }
                else if (inputEvent.KeyCode == inputProfile.RightKey)
                {
                    side -= 1;
                    playerDirections |= PlayerDirections.Right;
                }
            }
            Vector3 forwardVector = Vector3.forward * forward;
            Vector3 sideVector = Vector3.left * side;
            Vector3 moveVector = (forwardVector + sideVector).normalized;
            return (moveVector, playerDirections);
        }

        public static Vector3 FromPlayerDirection(PlayerDirections directions)
        {
            int forward = 0;
            int side = 0;
            if (directions.HasFlag(PlayerDirections.Frontward))
            {
                forward += 1;
            }
            if (directions.HasFlag(PlayerDirections.Backward))
            {
                forward -= 1;
            }
            if (directions.HasFlag(PlayerDirections.Left))
            {
                side += 1;
            }
            if (directions.HasFlag(PlayerDirections.Right))
            {
                side -= 1;
            }
            Vector3 forwardVector = Vector3.forward * forward;
            Vector3 sideVector = Vector3.left * side;
            Vector3 moveVector = (forwardVector + sideVector).normalized;
            return moveVector;
        }
    }
}
