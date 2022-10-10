using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basics
{
    public class TurretBuilder : MonoBehaviour
    {

        public static TurretBuilder Instance;   

        void Awake()
        {

            if (Instance != null)
            {
                return;
            }

            Instance = this;
        }

        public GameObject PrefabTurret;

        void Start()
        {
            TurretToBuild = PrefabTurret;
        }

        private GameObject TurretToBuild;

        public GameObject GiveTurretToBuild()
        {
            return TurretToBuild;
        }
    }
}