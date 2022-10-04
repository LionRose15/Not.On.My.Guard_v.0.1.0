using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Basics
{
    public class GridConfig : MonoBehaviour
    {

        public Color _Color;
        private Color DefaultColor;

        private GameObject _Turret;
        private Renderer _Renderer;

        public Vector3 OnClickPosition;

        void Start()
        {
            _Renderer = GetComponent<Renderer>();
            DefaultColor = _Renderer.material.color;
        }

        void OnMouseEnter()
        {
            _Renderer.material.color = _Color;      
        }

        void OnMouseDown()
        {           

            if (_Turret != null)
            {
                Debug.Log("Can´t build there");
                return;
            }

            GameObject TurretToBuild = TurretBuilder.Instance.GiveTurretToBuild();
            _Turret = (GameObject)Instantiate(TurretToBuild, transform.position + OnClickPosition, transform.rotation);
        }         

        void OnMouseExit()
        {
            _Renderer.material.color = DefaultColor;
        }
    }
}