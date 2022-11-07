using UnityEngine;

using UnityEngine.EventSystems;

namespace Basics
{
    public class GridSelector : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Color _EnableColor;
        public Color _DisableColor;
        private Color DefaultColor;

        public GameObject _Turret;
        private Renderer _Renderer;

        TurretBuilder _TurretBuilder;
        public Vector3 OnClickPosition;

        void Start()
        {
            _Renderer = GetComponent<Renderer>();
            DefaultColor = _Renderer.material.color;

            _TurretBuilder = TurretBuilder.Instance;
        }

        public Vector3 GetBuildPosition()
        {
            return transform.position + OnClickPosition; 
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_TurretBuilder.CanBuild)
                return;

            if (_Turret != null)
            {
                Debug.Log("Can´t build there");
                return;
            }

            _TurretBuilder.BuildTurretOn(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!_TurretBuilder.CanBuild)
                return;

            if (!_TurretBuilder.HasMoney)
            {
                _Renderer.material.color = _DisableColor;              
            }

            else
            {
                _Renderer.material.color = _EnableColor;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _Renderer.material.color = DefaultColor;
        }
    }
}