using UnityEngine;

namespace Basics
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 0.5f;

        private float _newRotation = default;
        private Vector3 _lastRotation = default;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _newRotation = Input.mousePosition.x;
                _lastRotation = transform.eulerAngles;
            }

            else if (Input.GetMouseButton(0))
            {
                var difference = Input.mousePosition.x - _newRotation;
                var newRotation = _lastRotation;

                newRotation.y = _lastRotation.y + (difference * _sensitivity);
                transform.eulerAngles = newRotation;
            }
        }
    }
}