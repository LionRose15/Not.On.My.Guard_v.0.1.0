using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basics
{
    public class BulletBasics : MonoBehaviour
    {

        public float BulletSpeed = 50f;
        private Transform _Target;

        void Update()
        {
            if(_Target == null )
            {
                Destroy(gameObject);
                return;
            }

            Vector3 Direction = _Target.position - transform.position;
            float Distance = BulletSpeed * Time.deltaTime;
            
            if (Direction.magnitude <= Distance)
            {
                Hit();
                return;
            }

            transform.Translate(Direction.normalized * Distance, Space.World);
        }

        public void Locate(Transform _target)
        {
            _Target = _target;
        }

        void Hit()
        {
            Destroy(_Target.gameObject);
            Destroy(gameObject);
        }
    }
}