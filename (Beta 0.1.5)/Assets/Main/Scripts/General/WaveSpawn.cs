using UnityEngine;

using System.Collections;
using UnityEngine.UI;

namespace Basics
{
    public class WaveSpawn : MonoBehaviour
    {

        public Transform PrefabEnemy;
        public Transform EnemySpawn;

        public float TimeInterval = 2f;

        public float Countdown = 1f;
        private int WaveRepetition = 0;

        public AudioClip SpawnSound;
        AudioSource _Audio;

        void Start()
        {
            _Audio = GetComponent<AudioSource>();
        }

        void Update()
        {

            if (Countdown <= 0f)
            {
                StartCoroutine(Spawning());
                Countdown = TimeInterval;
            }

            Countdown -= Time.deltaTime;
        }

        IEnumerator Spawning()
        {
            WaveRepetition++;
            _Audio.PlayOneShot(SpawnSound);

            for (int X = 0; X < WaveRepetition; X++)
            {
                EnemySpawning();
                yield return new WaitForSeconds(2.5f);
            }
        }

        void EnemySpawning()
        {
            Instantiate(PrefabEnemy, EnemySpawn.position, EnemySpawn.rotation);
        }
    }
}