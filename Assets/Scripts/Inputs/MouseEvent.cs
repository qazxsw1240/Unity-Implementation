using UnityEngine;

namespace Implementation.Inputs
{
    public readonly struct MouseEvent
    {
        public MouseEvent(GameObject origin, Vector3 originPosition, GameObject target, Vector3 targetPosition)
        {
            Origin = origin;
            OriginPosition = originPosition;
            Target = target;
            TargetPosition = targetPosition;
        }

        public GameObject Origin { get; }

        public Vector3 OriginPosition { get; }

        public GameObject Target { get; }

        public Vector3 TargetPosition { get; }
    }
}
