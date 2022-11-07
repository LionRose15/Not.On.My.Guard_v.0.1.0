using UnityEngine;

namespace Basics
{
    public class GameManager : MonoBehaviour
    {
        public static bool GameEnded;

        public GameObject UIGameOver;

        void Start()
        {
            GameEnded = false;
        }

        void Update()
        {

            if (GameEnded)
                return;

            if(PlayerStatus.Health <= 0)
            {
                EndGame();
            }
        }

        void EndGame()
        {
            GameEnded = true;
            UIGameOver.SetActive(true);

        }
    }
}