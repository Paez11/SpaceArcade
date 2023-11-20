using UnityEngine;

namespace Ships.CheckLimits
{
    public class InitialPositionCheckLimits : CheckLimit
    {
        private readonly Transform _transform;
        private readonly Vector3 _initialPosition;
        private readonly float _maxDistance;

        public InitialPositionCheckLimits(Transform transform, float maxDistance)
        {
            _transform = transform;
            _initialPosition = _transform.position;
            _maxDistance = maxDistance;
        }
        public void ClampFinalPosition()
        {
            var currentPosition = _transform.position;
            var finalPosition = currentPosition;
            var distance = Mathf.Abs(currentPosition.x - _initialPosition.x);
            if(distance <= _maxDistance)
                return;
            if(distance > _maxDistance)
            {
                if(currentPosition.x > _initialPosition.x)
                {
                   finalPosition.x = _initialPosition.x + _maxDistance;
                }
                else
                {
                    finalPosition.x = _initialPosition.x - _maxDistance;
                }
                _transform.position = finalPosition;
            }
        }
    }
}