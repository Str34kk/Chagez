using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour {

    public GameObject gameControllerObject;
    GameController gc;
    public GameObject Value;
    TextMesh healthValue;

    int rmdColor;
    SpriteRenderer sr;
    Color newColor;

    public int Health { get; set; }

    void Start () {
        if (gameControllerObject == null)
            gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        gc = gameControllerObject.GetComponent<GameController>();

        Health = Random.Range(0, gc.Scorce);
        if (Health <= 0)
            Health = 1;

        healthValue = Value.GetComponent<TextMesh>();
        healthValue.text = Health.ToString();

        sr = GetComponent<SpriteRenderer>();
        rmdColor = Random.Range(0, 5);

        //random kolor dla blokow
        switch (rmdColor)
        {
            case 0:
                newColor = Color.Lerp(Color.white, Color.blue, 0.9f);
                break;
            case 1:
                newColor = Color.Lerp(Color.white, Color.red, 0.9f);
                break;
            case 2:
                newColor = Color.Lerp(Color.white, Color.cyan, 0.9f);
                break;
            case 3:
                newColor = Color.Lerp(Color.white, Color.magenta, 0.9f);
                break;
            case 4:
                newColor = Color.Lerp(Color.white, Color.yellow, 0.9f);
                break;
            default:
                break;
        }
        sr.color = newColor;
        healthValue.color = newColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Usuwanie przy spotkaniu z graczem
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
