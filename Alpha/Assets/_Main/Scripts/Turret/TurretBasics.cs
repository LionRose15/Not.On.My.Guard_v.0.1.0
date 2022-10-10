using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basics
{
    public class TurretBasics : MonoBehaviour
    {

        [Header(" General Config ")]

        public string Tag = "Enemy";
        public float VisionRange = 4f;
        public float TurnSpeed = 10f;
        public float RateFire = 1f;

        private float FireCountdown = 0f;

        [Header(" Turrets Parts ")]

        public Transform RotatePart;
        public Transform FireAim;

        private Transform Target;

        [Header(" Prefab ")]

        public GameObject PrefabBullet;

        void Start()
        {
            InvokeRepeating("UpdateTarget", 0f, 0.4f);
        }

        void Update()
        {

            if (Target == null)
                return;

            Vector3 Direction = Target.position - transform.position;
            Quaternion RotationToLooking = Quaternion.LookRotation(Direction);
            Vector3 Rotation = Quaternion.Lerp(RotatePart.rotation,RotationToLooking,Time.deltaTime * TurnSpeed).eulerAngles;
            
            RotatePart.rotation = Quaternion.Euler (0f,Rotation.y,0f);

            if(FireCountdown <= 0f)
            {
                Shoot();
                FireCountdown = 1f / RateFire;
            }

            FireCountdown -= Time.deltaTime;
        }

        void Shoot()
        {
            GameObject _Bullet = (GameObject)Instantiate(PrefabBullet, FireAim.position, FireAim.rotation);
            BulletBasics _bullet = _Bullet.GetComponent<BulletBasics>();

            if (_bullet != null)
                _bullet.Locate(Target);
        }

        void UpdateTarget()
        {
            GameObject[] Enemy = GameObject.FindGameObjectsWithTag(Tag);
            GameObject NearEnemy = null;

            float ShortDistance = Mathf.Infinity;

            foreach (GameObject _Enemy in Enemy)
            {
                float EnemyDistance = Vector3.Distance(transform.position, _Enemy.transform.position);

                if(EnemyDistance < ShortDistance)
                {
                    ShortDistance = EnemyDistance;
                    NearEnemy = _Enemy;
                }
            }

            if (NearEnemy != null && ShortDistance <= VisionRange)
            {
                Target = NearEnemy.transform;
            }

            else
            {
                Target = null; 
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, VisionRange);
        }
    }
}