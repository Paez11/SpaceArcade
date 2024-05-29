using UnityEngine;

namespace Ships.CheckLimits
{
    public interface CheckLimit
    {
        Vector2 ClampFinalPosition(Vector2 _currentPosition);
    }
}