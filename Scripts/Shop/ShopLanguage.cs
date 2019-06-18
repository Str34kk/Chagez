using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopLanguage : MonoBehaviour {

    public Text play;

    private void Awake()
    {
        play = play.GetComponent<Text>();

        if (Application.systemLanguage == SystemLanguage.Polish)
        {
            play.text = "Dotknij aby zagrać";
        }
    }
}
