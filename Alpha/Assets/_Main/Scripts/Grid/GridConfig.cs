using UnityEngine;
using UnityEngine.EventSystems;

namespace Basics
{
    public class GridConfig : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
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

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_Turret != null)
            {
                Debug.Log("Can´t build there");
                return;
            }

            GameObject TurretToBuild = TurretBuilder.Instance.GiveTurretToBuild();
            _Turret = (GameObject)Instantiate(TurretToBuild, transform.position + OnClickPosition, transform.rotation);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _Renderer.material.color = _Color;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _Renderer.material.color = DefaultColor;
        }
    }
}