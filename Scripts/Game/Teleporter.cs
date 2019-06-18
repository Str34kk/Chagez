using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	void Start () {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
