using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basics
{
    public class EnemyBasics : MonoBehaviour
    {

        public float Speed = 10f;

        private Transform _Target;
        private int PositionIndex = 0;

        void Start()
        {
            _Target = TurretPosition.Pos[0];
        }

        void Update()
        {
            Vector3 Direction = _Target.position - transform.position;
            transform.Translate(Direction.normalized * Speed * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, _Target.position) <= 2f)
            {
                /* if (TurretLife <= 100)
                 {

                 }
                 else
                 {
                 } */

                GoNextPosition();
            }
        }
        void GoNextPosition()
        {

            if (PositionIndex >= TurretPosition.Pos.Length - 1)
            {
                /*Speed = 0;*/
                Destroy(gameObject);
            }

            PositionIndex++;
            _Target = TurretPosition.Pos[PositionIndex];
        }
    }
}