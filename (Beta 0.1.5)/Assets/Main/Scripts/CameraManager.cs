using UnityEngine;

namespace Basics
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Camera _Camera;
        [SerializeField] private Transform _FocusPoint;

        private Vector3 _Position;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _Position = _Camera.ScreenToViewportPoint(Input.mousePosition);
            }

            else if (Input.GetMouseButton(0))
            {
                Vector3 NewPosition = _Camera.ScreenToViewportPoint(Input.mousePosition);
                Vector3 Direction = _Position - NewPosition;

                float RotationY = -Direction.x * 180;

                _Camera.transform.position = _FocusPoint.position;
                _Camera.transform.Rotate(new Vector3(0, 1, 0), RotationY, Space.World);

                _Position = NewPosition;
            }
        }
    }
}