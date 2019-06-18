using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageChecker : MonoBehaviour {

    public Text scorceTxtPause;
    public Text scorceTxtGO;
    public Text bestTxt;
    public Text bestTxtPause;
    public Text bestTxtGO;
    public Text holdToBeFaster;
    public Text extraLife;
    public Text tapToContinue;
    public Text pause;
    public Text tryAgain;
    public Text shop;
    public Text gameOver;
    public Text stars;
    public Text tip;

    string[] rada = new string[2];
    string[] tips = new string[2];


    private void Awake()
    {

        scorceTxtPause = scorceTxtPause.GetComponent<Text>();
        scorceTxtGO = scorceTxtGO.GetComponent<Text>();
        bestTxt = bestTxt.GetComponent<Text>();
        bestTxtPause = bestTxtPause.GetComponent<Text>();
        bestTxtGO = bestTxtGO.GetComponent<Text>();
        holdToBeFaster = holdToBeFaster.GetComponent<Text>();
        extraLife = extraLife.GetComponent<Text>();
        tapToContinue = tapToContinue.GetComponent<Text>();
        pause = pause.GetComponent<Text>();
        tryAgain = tryAgain.GetComponent<Text>();
        shop = shop.GetComponent<Text>();
        gameOver = gameOver.GetComponent<Text>();
        stars = stars.GetComponent<Text>();
        tip = tip.GetComponent<Text>();

        rada[0] = "Tip: Nie dotykaj kolców!";
        rada[1] = "Tip: Nie możesz zniszczyć bloków które mają więcej pkt od twoich gwiazdek!";
        tips[0] = "Tip: Do not touch the spikes!";
        tips[1] = "Tip: You can not destroy blocks that have more points than your stars!";

        if (Application.systemLanguage == SystemLanguage.Polish)
        {
            scorceTxtPause.text = "Wynik";
            scorceTxtGO.text = "Wynik";
            bestTxt.text = "Najlepszy";
            bestTxtPause.text = "Najlepszy";
            bestTxtGO.text = "Najlepszy";
            holdToBeFaster.text = "Przytrzymaj aby poruszać się szybciej";
            extraLife.text = "Ekstra szansa i 100 gwiazdek!";
            tapToContinue.text = "DOTKIN ABY WZNOWIĆ";
            pause.text = "PAUZA";
            tryAgain.text = "SPRÓBUJ PONOWNIE";
            shop.text = "SKLEP";
            gameOver.text = "KONIEC GRY!";
            stars.text = "Gwiazdki";

            tip.text = rada[Random.Range(0,2)];
        }
        else
        {
            tip.text = tips[Random.Range(0, 2)];
        }
    }
}
