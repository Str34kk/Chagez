using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butto : MonoBehaviour {

    public void GoToMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
    public void GoToGame()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
