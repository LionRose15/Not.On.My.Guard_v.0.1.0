using UnityEngine;

using UnityEditor.Experimental.GraphView;

namespace Basics
{
    public class TurretBuilder : MonoBehaviour
    {
        public static TurretBuilder Instance;
        private TurretBlueprint TurretToBuild;

        public GameObject PrefabTurret;

        public AudioClip PlaceSound;
        AudioSource _Audio;

        void Start()
        {
            _Audio = GetComponent<AudioSource>();
        }

        void Awake()
        {

            if (Instance != null)
            {
                return;
            }

            Instance = this;
        }

        public bool CanBuild { get { return TurretToBuild != null; } }
        public bool HasMoney { get { return PlayerStatus.Money >= TurretToBuild.Cost; } }

        public void BuildTurretOn(GridSelector _GridSelector)
        {

            if (PlayerStatus.Money < TurretToBuild.Cost)
            {
                Debug.Log("No Money");
                return;
            }

            PlayerStatus.Money -= TurretToBuild.Cost;

            GameObject Turret = (GameObject)Instantiate(TurretToBuild.Prefab, _GridSelector.GetBuildPosition(), Quaternion.identity);
            _GridSelector._Turret = Turret;

            _Audio.PlayOneShot(PlaceSound);
            Debug.Log("Turret Build Money left: " + PlayerStatus.Money);
        }

        public void SelectTurretToBuild(TurretBlueprint _Turret)
        {
            TurretToBuild = _Turret;
        }
    }
}