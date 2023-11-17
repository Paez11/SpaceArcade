using UnityEngine;

namespace ships
{
    public class ViewportCheckLimits : CheckLimits
    {
        private readonly Transform _transform;
        private readonly Camera _camera;

        public ViewportCheckLimits(Transform transform, Camera camera)
        {
            _transform = transform;
            _camera = camera;
        }
        public void ClampFinalPosition()
        {
            var viewportPoin = _camera.WorldToViewportPoint(_transform.position);
            viewportPoin.x = Mathf.Clamp(viewportPoin.x, 0.03f, 0.97f);
            viewportPoin.y = Mathf.Clamp(viewportPoin.y, 0.03f, 0.97f);
            _transform.position = _camera.ViewportToWorldPoint(viewportPoin);
        }
    }
}