using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basics
{
    public class CameraMovement : MonoBehaviour
    {

        [SerializeField] private Camera _Camera;
        [SerializeField] private Transform CameraFocus;
        [SerializeField] private float DistanceToFocus = 40;

        private Vector3 PrevPosition;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PrevPosition = _Camera.ScreenToViewportPoint(Input.mousePosition);
            }

            else if (Input.GetMouseButton(0))
            {
                Vector3 NewPosition = _Camera.ScreenToViewportPoint(Input.mousePosition);
                Vector3 Direction = PrevPosition - NewPosition;

                float RotationY = -Direction.x * 180;


                _Camera.transform.position = CameraFocus.position;
                _Camera.transform.Rotate(new Vector3(0, 1, 0), RotationY, Space.World);
                _Camera.transform.Translate(new Vector3(0, 0, -DistanceToFocus));

                PrevPosition = NewPosition;
            }
        }
    }
}