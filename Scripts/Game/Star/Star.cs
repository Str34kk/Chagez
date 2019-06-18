using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    GameObject ball;
    Quaternion StarRotation;
    Vector3 StarPosition;

    float timer;
    int rmd;

    void Start()
    {
        if (ball == null)
            ball = GameObject.FindGameObjectWithTag("Player");
        StarRotation.Set(0,0,0,0);
    }

    void Update () {
        if (ball.transform.position.y - transform.position.y > 6f)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(0, -0.7f * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
