using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    GameObject ball;

    int rmdColor;
    SpriteRenderer sr;
    Color newColor;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rmdColor = Random.Range(0, 5    );
        if (ball == null)
            ball = GameObject.FindGameObjectWithTag("Player");

        //Random kolor dla kolcow
        switch (rmdColor)
        {
            case 0:
                newColor = Color.Lerp(Color.white, Color.blue, 0.7f);
                break;
            case 1:
                newColor = Color.Lerp(Color.white, Color.red, 0.7f);
                break;
            case 2:
                newColor = Color.Lerp(Color.white, Color.cyan, 0.7f);
                break;
            case 3:
                newColor = Color.Lerp(Color.white, Color.magenta, 0.7f);
                break;
            case 4:
                newColor = Color.Lerp(Color.white, Color.yellow, 0.7f);
                break;
            default:
                break;
        }
        sr.color = newColor;
    }

    private void Update()
    {
        //Usuniecie bloku nizej niz gracz
        if (ball.transform.position.y - transform.position.y > 4f)
        {
            Destroy(this.gameObject);
        }
    }
}
