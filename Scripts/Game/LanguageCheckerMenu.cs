using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageCheckerMenu : MonoBehaviour {

    public Text play;
    public Text shop;

    private void Awake()
    {
        play = play.GetComponent<Text>();
        shop = shop.GetComponent<Text>();

        if (Application.systemLanguage == SystemLanguage.Polish)
        {
            play.text = "Graj";
            shop.text = "Sklep";
        }
    }
}
