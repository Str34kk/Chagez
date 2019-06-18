using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstlacleDestroyer : MonoBehaviour {

    GameObject ball;

    void Start () {
        if (ball == null)
            ball = GameObject.FindGameObjectWithTag("Player");
    }
	
	void Update () {
        if (ball.transform.position.y - transform.position.y > 6f)
        {
            Destroy(this.gameObject);
        }
    }
}
