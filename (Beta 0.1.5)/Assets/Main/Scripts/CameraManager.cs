using UnityEngine;

namespace Basics
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private float Sensitivity = 0.5f;

        private float _NewRotation = default;
        private Vector3 _LastRotation = default;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _NewRotation = Input.mousePosition.x;
                _LastRotation = transform.eulerAngles;
            }

            else if (Input.GetMouseButton(0))
            {
                var difference = Input.mousePosition.x - _NewRotation;
                var newRotation = _LastRotation;

                newRotation.y = _LastRotation.y + (difference * Sensitivity);
                transform.eulerAngles = newRotation;
            }
        }
    }
}