using UnityEngine;

namespace Basics
{
    public class BasicsEnemy : MonoBehaviour
    {
        [HideInInspector]
        public float Speed;
        public float InitialSpeed = 10f;

        public float InitialHealth = 100;
        private float _Health;

        public int Value = 50;
        private bool _IsDead = false;

        void Start()
        {
            Speed = InitialSpeed;
            _Health = InitialHealth;
        }

        public void TakeDamage (float _Amount)
        {
            _Health -= _Amount;

            if (_Health <= 0 && !_IsDead)
            {
                Dead();
            }
        }

        void Dead()
        {
            _IsDead = true;
            PlayerStatus.Money += Value;

            Destroy(gameObject);
        }
    }
}