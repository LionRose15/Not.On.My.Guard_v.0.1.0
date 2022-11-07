using UnityEngine;

namespace Basics
{
    public class Waypoints : MonoBehaviour
    {
        public static Transform[] _Waypoints;

        void Awake()
        {
            _Waypoints = new Transform[transform.childCount];

            for (int X = 0; X < _Waypoints.Length; X++)
            {
                _Waypoints[X] = transform.GetChild(X);
            }
        }
    }
}