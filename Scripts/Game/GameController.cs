using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int Scorce { get; set; }
    public int Power { get; set; }

    public Text scorceTxt;
    public Text powerTxt;
    public Text bestTxt;
    public Text scorceTxtGO;
    public Text bestTxtGO;
    public Text scorceTxtPause;
    public Text bestTxtPause;

    public GameObject tapToBeFaster;
    public GameObject tapPanel;
    public Sprite tap1;
    public Sprite tap2;
    int iTap;
    float timer;
    bool tapped;

    void Start () {
        //AdController.Instance.ShowBanner();
        //Zmiana scorcepanel
        scorceTxt = scorceTxt.GetComponent<Text>();
        powerTxt = powerTxt.GetComponent<Text>();
        bestTxt = bestTxt.GetComponent<Text>();
        scorceTxtGO = scorceTxtGO.GetComponent<Text>();
        bestTxtGO = bestTxtGO.GetComponent<Text>();
        scorceTxtPause = scorceTxtPause.GetComponent<Text>();
        bestTxtPause = bestTxtPause.GetComponent<Text>();
        //Zmiana wielkosci kamery dla innych rozdzielczosci
        Camera.main.orthographicSize = (6.6f / Screen.width * Screen.height / 2.0f);

        PlayerPrefs.SetInt("bestScorce", PlayerPrefs.GetInt("bestScorce"));
        bestTxt.text = bestTxtGO.text = bestTxtPause.text = PlayerPrefs.GetInt("bestScorce").ToString();
        tapped = false;
        tapPanel.SetActive(true);
    }

	void Update () {
        //Zmiana scorcepanel
        scorceTxt.text = scorceTxtGO.text = scorceTxtPause.text = Scorce.ToString();
        powerTxt.text = Power.ToString();

        if (Scorce > PlayerPrefs.GetInt("bestScorce"))
        {
            PlayerPrefs.SetInt("bestScorce", Scorce);
            bestTxt.text = bestTxtGO.text = bestTxtPause.text = scorceTxt.text;
        }

        timer += Time.deltaTime;

        //animacja tappanel
        if (timer >= 0.8f && tapped == false)
        {
            if(iTap % 2 == 0)
            {
                tapToBeFaster.GetComponent<Image>().sprite = tap2;
                iTap++;
            }
            else if (iTap % 2 == 1)
            {
                tapToBeFaster.GetComponent<Image>().sprite = tap1;
                iTap++;
            }
            timer = 0;
        }
        //usnunięcie tap panel
        if (tapped == false && Input.touchCount > 0 && timer >= 0.2f)
        {
            tapped = true;
            tapPanel.SetActive(false);
        }
        //klawisze na smartfonie
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause.Instance.deathPanel.active)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
            }
            else if (Pause.Instance.PausePanel.active)
            {
                Pause.Instance.ContinueGame();
            }
            else if (!Pause.Instance.PausePanel.active)
            {
                Pause.Instance.PauseGame();
            }
        }
    }
    //pauza w aplikacji
    private void OnApplicationPause(bool pause)
    {
        Pause.Instance.PauseGame();
    }
}
