using UnityEngine;

namespace Basics
{

    public class Shop : MonoBehaviour
    {
        public TurretBlueprint Crossbow;
        TurretBuilder _TurretBuilder;

        void Start()
        {
            _TurretBuilder = TurretBuilder.Instance;
        }

        public void SelectCrossbow()
        {
            Debug.Log("Crossbow Selected");
            _TurretBuilder.SelectTurretToBuild(Crossbow);
        }
    }
}