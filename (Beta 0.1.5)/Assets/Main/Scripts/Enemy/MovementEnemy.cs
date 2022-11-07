using UnityEngine;

using static UnityEngine.GraphicsBuffer;

namespace Basics
{

    [RequireComponent(typeof(BasicsEnemy))]

    public class MovementEnemy : MonoBehaviour
    {
        private Transform _Target;
        private int _WaypointIndex = 0;

        private BasicsEnemy _Enemy;

        void Start()
        {
            _Enemy = GetComponent<BasicsEnemy>();
            _Target = Waypoints._Waypoints[0];
        }

        void Update()
        {
            Vector3 Dir = _Target.position - transform.position;
            transform.Translate(Dir.normalized * _Enemy.Speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, _Target.position) <= 0.4f)
            {
                GoNextWaypoint();
            }

            _Enemy.Speed = _Enemy.InitialSpeed;
        }

        void GoNextWaypoint()
        {
            if (_WaypointIndex >= Waypoints._Waypoints.Length - 1)
            {
                Finish();
                return;
            }

            _WaypointIndex++;
            _Target = Waypoints._Waypoints[_WaypointIndex];
        }

        void Finish()
        {
            PlayerStatus.Health--;

            Destroy(gameObject);
        }
    }
}