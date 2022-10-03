using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basics
{
    public class TurretPosition : MonoBehaviour
    {

        public static Transform[] Pos;

        void Awake()
        {
            Pos = new Transform[transform.childCount];

            for (int X = 0; X < Pos.Length; X++)
            {
                Pos[X] = transform.GetChild(X);
            }
        }
    }
}