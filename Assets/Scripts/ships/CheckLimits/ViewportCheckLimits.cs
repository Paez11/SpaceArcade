using UnityEngine;

namespace Ships.CheckLimits
{
    public class ViewportCheckLimits : CheckLimit
    {
        private readonly Camera _camera;

        public ViewportCheckLimits(Camera camera)
        {
            _camera = camera;
        }
        public Vector2 ClampFinalPosition(Vector2 currentPosition)
        {
            var viewportPoin = _camera.WorldToViewportPoint(currentPosition);
            viewportPoin.x = Mathf.Clamp(viewportPoin.x, 0.03f, 0.97f);
            viewportPoin.y = Mathf.Clamp(viewportPoin.y, 0.03f, 0.97f);
            return _camera.ViewportToWorldPoint(viewportPoin);
        }
    }
}