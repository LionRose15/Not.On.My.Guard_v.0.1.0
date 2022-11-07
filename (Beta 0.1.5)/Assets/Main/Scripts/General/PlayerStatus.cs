using UnityEngine;

using System.Collections;

namespace Basics
{
    public class PlayerStatus : MonoBehaviour
    {
        public static int Money;
        public int StartingMoney = 250;

        public static int Health;
        public int StartingHealth = 100;

        public static int Rounds;

        void Start()
        {
            Money = StartingMoney;
            Health = StartingHealth;

            Rounds = 0;
        }
    }
}