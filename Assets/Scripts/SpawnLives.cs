using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLives : MonoBehaviour
{
    public GameObject lives;
    public int scoreLives;

    private void Start()
    {
        Spawn();
        scoreLives = 3;
    }

    void Spawn()
    {
        Instantiate(lives, new Vector3(1f, 0f, 0f), Quaternion.identity);
        GameObject.Find("Lives(Clone)").name = "Lives3";
        Instantiate(lives, new Vector3(0.5f, 0f, 0f), Quaternion.identity);
        GameObject.Find("Lives(Clone)").name = "Lives2";
        Instantiate(lives, new Vector3(0f, 0f, 0f), Quaternion.identity);
        GameObject.Find("Lives(Clone)").name = "Lives1";
    }
}