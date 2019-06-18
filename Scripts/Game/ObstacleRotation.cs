using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour {

    bool left;
    bool right;

	void Update () {

        if (transform.rotation.z >= 0.34f)
        {
            right = true;
            left = false;
        }
        else if (transform.rotation.z <= -0.32f)
        {
            left = true;
            right = false;
        }

        if(left)
        {
            transform.Rotate(0, 0, 1f);
        }
        if (right)
        {
            transform.Rotate(0, 0, -1f);
        }
    }
}
