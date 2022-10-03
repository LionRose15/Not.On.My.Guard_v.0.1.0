using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basics
{
    public class WaveSpawner : MonoBehaviour
    {

        public Transform PrefabEnemy;
        public Transform EnemySpawnPoint;

        public float TimeInterval = 2f;

        public float Countdown = 1f;
        private int WaveRepetition = 0;

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

            for (int X = 0; X < WaveRepetition; X++)
            {
                EnemySpawning();
                yield return new WaitForSeconds(2.5f);
            }
        }

        void EnemySpawning()
        {
            Instantiate(PrefabEnemy, EnemySpawnPoint.position, EnemySpawnPoint.rotation);
        }
    }
}