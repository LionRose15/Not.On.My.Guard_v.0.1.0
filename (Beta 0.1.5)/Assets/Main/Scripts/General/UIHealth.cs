using UnityEngine;

using UnityEngine.UI;

namespace Basics
{
    public class UIHealth : MonoBehaviour
    {
        public Text _HealthUI;
        void Update()
        {
            _HealthUI.text = PlayerStatus.Health.ToString() + "% Health";
        }
    }
}