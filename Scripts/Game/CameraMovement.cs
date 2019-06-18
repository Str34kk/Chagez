using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject Ball;

    private void Update()
    {
        //Ruch kamery w gore
        transform.position = new Vector3 (0, Ball.transform.position.y + 3f, -10);
    }
}
