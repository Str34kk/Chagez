using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneController : MonoBehaviour {

    float timer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (timer > 0)
            {
                Application.Quit();
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= 1f)
                {
                    timer = 0;
                }
            }
        }
    }
}
