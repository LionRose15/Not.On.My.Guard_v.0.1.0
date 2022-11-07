using UnityEngine;

using UnityEngine.UI;

namespace Basics
{
    public class UIMoney : MonoBehaviour
    {
        public Text _MoneyUI;

        void Update()
        {
            _MoneyUI.text = "$ " + PlayerStatus.Money.ToString();
        }
    }
}