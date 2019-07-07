using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vorobey : MonoBehaviour
{
    public float speed = 3f;

    private void FixedUpdate()
    {
        //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        //transform.position = new Vector3(pos.x, transform.position.y, transform.position.z);
        //if (pos.x <= 0) {
        //transform.localScale = new Vector2(1, 1);
        //} else {
        //transform.localScale = new Vector2(-1, 1);
        //}

        float hor = Input.GetAxisRaw("Horizontal");
        if (hor <= 0)
        {
            Vector3 dir = new Vector3(hor, 0, 0);
            transform.Translate(dir.normalized * Time.deltaTime * speed);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            Vector3 dir = new Vector3(hor, 0, 0);
            transform.Translate(dir.normalized * Time.deltaTime * speed);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        SpawnLives sl = gameObject.GetComponent<SpawnLives>();

        if (other.gameObject.CompareTag("Seed"))
        {
            if (ScoreManager.score >= -2 && ScoreManager.score <= 10)
            {
                ScoreManager.score++;
                SpawnSeed.waitForSeconds = new WaitForSeconds(3f);
                SpawnGrenade.waitForSeconds = new WaitForSeconds(4f);
                SpawnLive.waitForSeconds = new WaitForSeconds(4f);
                MoveObjectSeed.speed = 2f;
                MoveObjectGrenade.speed = 2.5f;
            }
            else if (ScoreManager.score > 10 && ScoreManager.score <= 70)
            {
                ScoreManager.score++;
                SpawnSeed.waitForSeconds = new WaitForSeconds(1.5f);
                SpawnGrenade.waitForSeconds = new WaitForSeconds(2f);
                SpawnLive.waitForSeconds = new WaitForSeconds(18f);
                MoveObjectSeed.speed = MoveObjectSeed.speed + 0.1f;
                MoveObjectGrenade.speed = MoveObjectGrenade.speed + 0.05f;
            }
            else if (ScoreManager.score > 70)
            {
                ScoreManager.score++;
                SpawnSeed.waitForSeconds = new WaitForSeconds(0.5f);
                SpawnGrenade.waitForSeconds = new WaitForSeconds(1f);
                SpawnLive.waitForSeconds = new WaitForSeconds(16f);
                MoveObjectSeed.speed = MoveObjectSeed.speed + 0.3f;
                MoveObjectGrenade.speed = MoveObjectGrenade.speed + 0.15f;
            }

            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Grenade"))
        {
            if (GameObject.Find("Lives3"))
            {
                Destroy(GameObject.Find("Lives3"));
                sl.scoreLives = 2;
                Destroy(other.gameObject);
            }
            else if (GameObject.Find("Lives2"))
            {
                Destroy(GameObject.Find("Lives2"));
                sl.scoreLives = 1;
                Destroy(other.gameObject);
            }
            else if (GameObject.Find("Lives1"))
            {
                Destroy(GameObject.Find("Lives1"));
                sl.scoreLives = 0;
                SceneManager.LoadScene(2);
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Live"))
        {
            if (sl.scoreLives == 3)
            {
                Destroy(other.gameObject);
            }
            else if (sl.scoreLives == 2)
            {
                Instantiate(sl.lives, new Vector3(1f, 0f, 0f), Quaternion.identity);
                GameObject.Find("Lives(Clone)").name = "Lives3";
                sl.scoreLives = 3;
                Destroy(other.gameObject);
            }
            else if (sl.scoreLives == 1)
            {
                Instantiate(sl.lives, new Vector3(0.5f, 0f, 0f), Quaternion.identity);
                GameObject.Find("Lives(Clone)").name = "Lives2";
                sl.scoreLives = 2;
                Destroy(other.gameObject);
            }
        }
    }
}