using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLives : MonoBehaviour {
    public GameObject lives;

    private void Start() {
        spawn();
    }

    void spawn() {
        Instantiate(lives, new Vector3(1f, 0f, 0f), Quaternion.identity);
        GameObject.Find("Lives(Clone)").name = "Lives3";
        Instantiate(lives, new Vector3(0.5f, 0f, 0f), Quaternion.identity);
        GameObject.Find("Lives(Clone)").name = "Lives2";
        Instantiate(lives, new Vector3(0f, 0f, 0f), Quaternion.identity);
        GameObject.Find("Lives(Clone)").name = "Lives1";
    }
}