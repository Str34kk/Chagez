using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public static Pause Instance { set; get; }

    public GameObject PausePanel;
    public GameObject deathPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        deathPanel.SetActive(false);
    }
    public void GoToMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
    public void GoToShop()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Shop");
    }
}
