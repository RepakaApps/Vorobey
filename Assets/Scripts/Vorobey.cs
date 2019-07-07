using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        //if (pos.x <= 0)
        //{
        //    transform.localScale = new Vector2(1, 1);
        //}
        //else
        //{
        //    transform.localScale = new Vector2(-1, 1);
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
                SpawnGrenade.waitForSeconds = new WaitForSeconds(6f);
                SpawnLive.waitForSeconds = new WaitForSeconds(40f);
                MoveObjectSeed.speed = 2f;
                MoveObjectGrenade.speed = 4f;
                MoveObjectLive.speed = 6f;
            }
            else if (ScoreManager.score > 10 && ScoreManager.score <= 70)
            {
                ScoreManager.score++;
                SpawnSeed.waitForSeconds = new WaitForSeconds(1.5f);
                SpawnGrenade.waitForSeconds = new WaitForSeconds(5f);
                SpawnLive.waitForSeconds = new WaitForSeconds(35f);
                MoveObjectSeed.speed = MoveObjectSeed.speed + 0.1f;
                MoveObjectGrenade.speed = 4.5f;
                MoveObjectLive.speed = 7f;
            }
            else if (ScoreManager.score > 70)
            {
                ScoreManager.score++;
                SpawnSeed.waitForSeconds = new WaitForSeconds(0.5f);
                SpawnGrenade.waitForSeconds = new WaitForSeconds(4f);
                SpawnLive.waitForSeconds = new WaitForSeconds(30f);
                MoveObjectSeed.speed = MoveObjectSeed.speed + 0.3f;
                MoveObjectGrenade.speed = 5.5f;
                MoveObjectLive.speed = 8f;
            }

            ZvukChirik zv1 = GetComponent<ZvukChirik>();
            zv1.Chirik();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Grenade"))
        {
            ZvukGrenade zg = GetComponent<ZvukGrenade>();
            
            if (GameObject.Find("Lives3"))
            {
                zg.Grenade();
                Destroy(GameObject.Find("Lives3"));
                sl.scoreLives = 2;
                Destroy(other.gameObject);
            }
            else if (GameObject.Find("Lives2"))
            {
                zg.Grenade();
                Destroy(GameObject.Find("Lives2"));
                sl.scoreLives = 1;
                Destroy(other.gameObject);
            }
            else if (GameObject.Find("Lives1"))
            {
                Destroy(GameObject.Find("Lives1"));
                sl.scoreLives = 0;
                if (PlayerPrefs.GetInt("MaxScore") < ScoreManager.score)
                {
                    PlayerPrefs.SetInt("MaxScore", ScoreManager.score);
                }

                PlayerPrefs.SetInt("Score", ScoreManager.score);
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