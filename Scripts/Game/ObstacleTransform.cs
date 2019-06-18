using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTransform : MonoBehaviour {

    float x = 0.02f;

	void Update () {
        transform.Translate(x, 0, 0);
        if (transform.position.x > 1.6 || transform.position.x < -1.6) x = x * -1;
	}
}
