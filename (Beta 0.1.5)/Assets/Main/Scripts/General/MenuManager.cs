using UnityEngine;

using UnityEngine.SceneManagement;

namespace Basics
{
    public class MenuManager : MonoBehaviour
    {
        public int SceneSelected;

        public void StartGame()
        {
            SceneManager.LoadScene(SceneSelected);
        }
    }
}