using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ManagerScene : MonoBehaviour
{
    public int SceneSelected;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneSelected);
    }
}