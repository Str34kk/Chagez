using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRB : MonoBehaviour {

    Rigidbody2D rb;
    //GameObject ball;
    //SpriteRenderer sr;


    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        //sr = GetComponent<SpriteRenderer>();
        //if (ball == null)
        //    ball = GameObject.FindGameObjectWithTag("Player");

        rb.AddForce(new Vector2(Random.Range(-300, 300), Random.Range(-100, 300)));

	}
	
}