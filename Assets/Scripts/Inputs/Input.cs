using UnityEngine;

namespace Inputs
{
    public interface Input
    {
        Vector2 GetDirection();
        bool IsFireActionPressed();
        bool IsMissileActionPressed();
    }
}